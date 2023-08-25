using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressController : BaseController
    {

        public AddressController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
            this.repo = repo;
        }

        [HttpGet("AllAddresses")]
        public dynamic Get()
        {
            List<tblAddress> items = repo.AddressRepository.FindAll().ToList<tblAddress>();
            return new
            {
                success = true,
                data = items
            };
        }
    }
}
