using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;

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

        [HttpGet("TümSatışlar")]
        public dynamic TumSatislar()
        {
            List<tblSale> Sales = repo.SaleRepository.FindAll().ToList();

            return new
            {
                success = true,
                data = Sales
            };  
        }

        [HttpGet("SatısaHazırUrunler")]
        public dynamic ReadySale()
        {
            List<tblSale> items = repo.SaleRepository.FindByCondition(z => z.Process == false).ToList<tblSale>();

            return new
            {
                success = true,
                data = items
            };
        }
        //[HttpGet("SatısaHazırUrunler")]
        //public dynamic ReadySale()
        //{
        //    List<tblSale> items = repo.SaleRepository.OfTheShelf().ToList();
        //    return new
        //    {
        //        success = true,
        //        data = items
        //    };
        //}

        [HttpGet("GerçekleşenSatışlar")]
        public dynamic Saled()
        {
            List<tblSale> items = repo.SaleRepository.FindByCondition(z => z.Process == true).ToList<tblSale>();

            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet("EsnafaGöreSatışlar/{tblTradesmanId}")]
        public dynamic SaleTradesman(int tradesmanId)
        {
            List<tblSale> items = repo.SaleRepository.FindByCondition(z => z.tblTradesmanId == tradesmanId).ToList<tblSale>();

            return new
            {
                success = true,
                data = items
            };
        }


        [HttpGet("ÇiftiçiyeGöreSatışlar/{tblFarmerId}")]
        public dynamic Get(int farmerId)
        {
            List<tblSale> items = repo.SaleRepository.FindByCondition(z => z.tblEntryProduct.tblFarmerId == farmerId).ToList<tblSale>();

            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet("TariheGöreSatışlar/{date}")]
        public dynamic SaleByDate(DateTime date)
        {
            List<tblSale> items = repo.SaleRepository.FindByCondition(z => z.Date == date).ToList<tblSale>();

            return new
            {
                success = true,
                data = items
            };
        }

        [HttpPost("SatışGir")]
        public dynamic EnterSale([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            tblSale item = new tblSale()
            {
                Id = json.Id,
                ActualPrice = json.ActualPrice,
                Amount = json.Amount,
                Quantity = json.Quantity,
                BasePrice = json.BasePrice,
                Date = DateTime.Now,
                Process = true,
                
            };

            repo.SaveChanges();
            return new
            {
                success = true,
                data = item
            };
        }

        
    }
}
