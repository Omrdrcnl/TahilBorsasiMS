using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TahilBorsa.Repository;


namespace TahilBorsa.Api.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected RepositoryWrapper repo;
        //cache dahil etme
        protected IMemoryCache cache;
        public BaseController(RepositoryWrapper repo, IMemoryCache cache)
        {
            this.repo = repo;
            this.cache = cache;
        }
      
    }
}
