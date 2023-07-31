using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryProductController : ControllerBase
    {
        private RepositoryWrapper repo;
        public EntryProductController(RepositoryWrapper repo)
        {
            this.repo = repo;
        }

        [HttpGet("GirisYapanUrunler")]
        public dynamic AllEntryProduct()
        {
            List<tblEntryProduct> tblEntryProducts = repo.EntryProductRepository.FindAll().ToList();
            return new
            {
                success = true,
                data = tblEntryProducts
            };
        }
    }
}
