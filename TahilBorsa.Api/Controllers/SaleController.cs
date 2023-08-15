using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;
using TahilBorsaMS.Models.Views;

namespace TahilBorsa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

            if(!cache.TryGetValue("TariheGöreSatışlar/{date}",out items))
            {
                items  = repo.SaleRepository.FindByCondition(z => z.Date == date).ToList<tblSale>();

                cache.Set("TariheGöreSatışlar/{date}", items, DateTimeOffset.UtcNow.AddDays(1));
            }  

            return new
            {
                success = true,
                data = items
            };
        }

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
                tblTradesmanId= json.TradesmanId,
                
            };

            if(item != null )
            {
                repo.SaleRepository.Update(item);
                repo.SaveChanges();
            }
           
            return new
            {
                success = true,
                data = item
            };
        }

        
    }
}
