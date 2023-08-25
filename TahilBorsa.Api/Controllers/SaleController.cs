using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;
using TahilBorsaMS.Models.Views;

namespace TahilBorsa.Api.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleController : BaseController
    {

        public SaleController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
            this.repo = repo;
        }

        [HttpGet("SaledList")]
        public dynamic SaledList()
        {
            List<V_SaledList> Sales = repo.SaleRepository.GetSaledList();

            return new
            {
                success = true,
                data = Sales
            };
        }

        [HttpGet("ReadySales")]
        public dynamic ReadySale()
        {
            List<V_ReadySale> items = repo.SaleRepository.GetReadySales();

            return new
            {
                success = true,
                data = items
            };
        }



        [HttpGet("SalesByTradesman/{tblTradesmanId}")]
        public dynamic SaleTradesman(int tradesmanId)
        {
            List<tblSale> items = repo.SaleRepository.FindByCondition(z => z.tblTradesmanId == tradesmanId).ToList<tblSale>();

            return new
            {
                success = true,
                data = items
            };
        }


        [HttpGet("SalesByFarmer/{tblFarmerId}")]
        public dynamic Get(int farmerId)
        {
            List<tblSale> items = repo.SaleRepository.FindByCondition(z => z.tblEntryProduct.tblFarmerId == farmerId).ToList<tblSale>();

            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet("SalesByDate/{date}")]
        public dynamic SaleByDate(DateTime date)
        {
            List<tblSale> items;

            if (!cache.TryGetValue("TariheGöreSatışlar/{date}", out items))
            {
                items = repo.SaleRepository.FindByCondition(z => z.Date == date).ToList<tblSale>();



                cache.Set("TariheGöreSatışlar/{date}", items, DateTimeOffset.UtcNow.AddDays(1));
            }

            return new
            {
                success = true,
                data = items
            };
        }

        //Toplam degerleri panele aktarma
        [HttpGet("Total")]
        public dynamic TotalQuantity()
        {
            var sales = repo.SaleRepository.FindAll().ToList<tblSale>();

            decimal? totalQuantity = sales.Sum(x => x.Quantity);
            var saleLength = sales.Count();
            decimal? totalAmount = sales.Sum(x => x.Amount);

            var tradesman = repo.TradesmanRepository.FindAll().ToList<tblTradesman>();

            int trLength = tradesman.Count();

            var farmer = repo.FarmerRepository.FindAll().ToList<tblFarmer>();

            var fLength = farmer.Count();

            var item = new
            {
                totalQuantity = totalQuantity,
                totalAmount = totalAmount,
                totalTradesman = trLength,
                totalSale = saleLength,
                totalFarmer = fLength,
            };

            return new
            {
                success = true,
                data = item
            };
        }

        //Toplam Miktarı panele aktar
        [HttpGet("ProTotal")]
        public dynamic ProTotal()
        {
            var Sales = repo.SaleRepository.GetSaledList();

            var pro = Sales.GroupBy(x => x.ProductName).Select(group => new
            {
                Product = group.Key,
                Quantity = group.Sum(x => x.Quantity),
            }).ToList();

            return new
            {
                success = true,
                data = pro
            };
        }
        //Toplam hacimi hesapla aktar
        [HttpGet("AmountChart")]
        public dynamic AmountChart()
        {
            var sales = repo.SaleRepository.GetChartsData();

            var salesByMonth = sales.GroupBy(s => s.Date.Month)
            .Select(group => new
            {
                Month = group.Key,
                Amount = group.Sum(s => s.Amount)
            }).ToDictionary(x => x.Month, x => x.Amount);

            return new
            {
                success = true,
                data = salesByMonth
            };
        }
        //ay ve ürün bazında gruplandır panele aktar
        [HttpGet("PriceChart")]
        public dynamic PriceChart()
        {
            var sales = repo.SaleRepository.GetChartsData();

            var salesByMonthAndProduct = sales.GroupBy(s => new { s.Date.Month, s.ProductName })
                .Select(group => new
                {
                    Month = group.Key.Month,
                    ProductName = group.Key.ProductName,
                    ActualPrice = group.Max(s => s.ActualPrice)
                }).ToList();

            return new
            {
                success = true,
                data = salesByMonthAndProduct
            };
        }
        //en iyi 10 satıcı
        [HttpGet("BestFarmers")]
        public dynamic BestFarmer()
        {
            var best = repo.SaleRepository.GetSaledList();

            var bestfarmers = best.GroupBy(s => new { s.FarmerFirstName, s.FarmerLastName, })
                .Select(group => new
                {
                    Name = group.Key.FarmerFirstName,
                    LastName = group.Key.FarmerLastName,
                    TotalQuantity = group.Sum(x => x.Quantity)
                }).OrderByDescending(x => x.TotalQuantity)
                .Take(10).ToList();


            return new
            {
                success = true,
                data = bestfarmers
            };

        }

        //En iyi 10 alıcı
        [HttpGet("BestTradesmans")]
        public dynamic BestTradesmans()
        {
            var best = repo.SaleRepository.GetSaledList();

            var bestTradesman = best.GroupBy(x => new { x.TrFirstName, x.TrLastName})
                .Select(group => new
                {
                    Name = group.Key.TrFirstName,
                    LastName = group.Key.TrLastName,
                    TotalQuantity = group.Sum(x => x.Quantity)
                }).OrderByDescending(x => x.TotalQuantity)
                .Take(10).ToList();

            return new
            {
                success = true,
                data = bestTradesman
            };

        }

        [Authorize(Roles = "admin, person")]

        [HttpPost("EnterSale")]
        public dynamic EnterSale([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            decimal actualPrice = Convert.ToDecimal(json.ActualPrice);
            int quantity = Convert.ToInt32(json.Quantity);

            decimal amount = actualPrice * quantity;


            tblSale item = new tblSale()
            {
                Id = json.Id,
                tblLabDataId = json.LabDataId,
                tblEntryProductId = json.EntryId,
                ActualPrice = json.ActualPrice,
                Quantity = json.Quantity,
                BasePrice = json.BasePrice,
                Amount = amount,
                Date = json.Date,
                Process = json.Process,
                tblTradesmanId = json.TradesmanId,

            };
            var tradesman = repo.TradesmanRepository.FindByCondition(x => x.Id == item.tblTradesmanId).FirstOrDefault();

            if (tradesman != null)
            {
                repo.SaleRepository.Update(item);
                repo.SaveChanges();

            }
            else
            {
                return new
                {
                    success = false,
                    message = "Bu Kayıt Numarasında Bir Esnaf Bulunmamaktadır..."
                };
            }




            return new
            {
                success = true,
                data = item
            };
        }


    }
}
