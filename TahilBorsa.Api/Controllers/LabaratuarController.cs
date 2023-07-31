using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabaratuarController : BaseController
    {
        
        public LabaratuarController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
            this.repo = repo;
        }

        [HttpGet("TumLabaratuarVeriler")]
        public dynamic AllLabData()
        {
            List<tblAddress> item = repo.AddressRepository.FindAll().ToList();

            return new
            {
                success = true,
                data = item
            };
        }
    }
}
