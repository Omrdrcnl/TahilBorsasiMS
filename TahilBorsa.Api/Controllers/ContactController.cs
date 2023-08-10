using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Controllers
{
    public class ContactController : BaseController
    {
        public ContactController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
            this.repo = repo;
        }


        [HttpGet("TumIletisimIstekleri")]
        public dynamic TumIller()
        {
            List<tblContact> item = repo.ContactRepository.FindAll().ToList<tblContact>();
            return new
            {
                success = true,
                data = item
            };
        }
    }
}
