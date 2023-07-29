using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private RepositoryWrapper repo;

        public CityController(RepositoryWrapper repo)
        {
            this.repo = repo;
        }


        [HttpGet("TumIller")]
        public dynamic TumIller() {
                List<tblCity> item = repo.CityRepository.FindAll().ToList<tblCity>();
            return new
            {
                success = true,
                data = item
            };
        }
    }
}
