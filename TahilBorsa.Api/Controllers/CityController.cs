using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : BaseController
    {

        public CityController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
            this.repo = repo;
        }


        [HttpGet("AllCity")]
        public dynamic AllCity() {
                List<tblCity> item = repo.CityRepository.FindAll().ToList<tblCity>();
            return new
            {
                success = true,
                data = item
            };
        }
    }
}
