using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private RepositoryWrapper repo;

        public ProductController(RepositoryWrapper repo)
        {
            this.repo = repo;
        }

        [HttpGet("Tum Urunler")]
        public dynamic TumUrunler()
        {
            List<tblProduct> products = repo.ProductRepository.FindAll().ToList();
            return new
            {
                success = true,
                data = products
            };
        }
    }
}
