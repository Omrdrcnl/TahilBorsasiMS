using Microsoft.AspNetCore.Mvc;
using TahilBorsa.Repository;


namespace TahilBorsa.Api.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected RepositoryWrapper repo;
        public BaseController(RepositoryWrapper repo)
        {
            this.repo = repo;
        }
      
    }
}
