using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabaratuarController : ControllerBase
    {
        private RepositoryWrapper repo;
        public LabaratuarController(RepositoryWrapper repo)
        {
            this.repo = repo;
        }

        [HttpGet("TumLabaratuarVeriler")]
        public dynamic AllLabData()
        {
            List<tblAddress> addresses = repo.AddressRepository.FindAll().ToList();

            return new
            {
                success = true,
                data = addresses
            };
        }
    }
}
