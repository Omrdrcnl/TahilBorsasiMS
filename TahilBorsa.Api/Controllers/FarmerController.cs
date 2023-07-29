using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerController : ControllerBase
    {
        private RepositoryWrapper repo;

        public FarmerController(RepositoryWrapper repo)
        {
            this.repo = repo;
        }

        [HttpGet("TumCiftciler")]
        public dynamic TumCiftciler()
        {
            List<tblFarmer> items = repo.FarmerRepository.FindAll().ToList<tblFarmer>();

            return new
            {
                success = true,
                data = items
            };
        }
    }
}
