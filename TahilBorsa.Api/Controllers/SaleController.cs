using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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

        [HttpGet("Tüm Satışlar")]
        public dynamic TumSatislar()
        {
            List<tblSale> Sales = repo.SaleRepository.FindAll().ToList();

            return new
            {
                success = true,
                data = Sales
            };
        }
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

        //[HttpGet("/{TradesmanId}")]
        //public dynamic SalaryByTradesman(int tradesmanId)
        //{
        //    List<tblSale> items = repo.SaleRepository.GetSaledByTradesman(tradesmanId);

        //    return new
        //    {
        //        success = true,
        //        data = items
        //    };
        //}
    }
}
