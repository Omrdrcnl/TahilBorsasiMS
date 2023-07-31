using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradesmanController : ControllerBase
    {
        private RepositoryWrapper repo;
        public TradesmanController(RepositoryWrapper repo)
        {
            this.repo = repo;
        }

        [HttpGet("Esnaflar")]
        public dynamic AllTradesman()
        {
            List<tblTradesman> Tradesmans = repo.TradesmanRepository.FindAll().ToList();
            return new
            {
                success = true,
                data = Tradesmans
            };
        }
    }
}
