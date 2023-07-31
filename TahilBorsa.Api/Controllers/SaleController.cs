using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private RepositoryWrapper repo;

        public SaleController(RepositoryWrapper repo)
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
        //[HttpGet("Gerçekleşen Satışlar")]
        //public dynamic Saled()
        //{
        //    List<tblSale> Saled = repo.SaleRepository.FindByCondition().Where(z=>z.Process=true).ToList();
        //}
    }
}
