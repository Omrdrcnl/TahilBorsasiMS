using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;
using static TahilBorsaMS.Models.Classes.Enums;

namespace TahilBorsa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]

    public class RolController : BaseController
    {
        public RolController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
            this.repo = repo;
        }


        [HttpGet("AllRoles")]
        public dynamic AllRoles()
        {
            List<tblRol> item = repo.RolRepository.FindAll().ToList<tblRol>();
            return new
            {
                success = true,
                data = item
            };
        }

        [HttpPost("Save")]
        public dynamic Save([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            tblRol item = new tblRol()
            {
                Id = json.Id,
                Name = json.Ad
            };
            if (string.IsNullOrEmpty(json.Ad))
            {
                return new
                {
                    success = false,
                    message = "Ad alanı boş geçilemez"
                };
            }

            if (item.Id > 0)
            {
                repo.RolRepository.Update(item);
            }
            else
            {
                repo.RolRepository.Create(item);
            }

            repo.SaveChanges();

            return new
            {
                success = true,
            };
        }

        [HttpDelete("Id")]
        public dynamic Delete(int id)
        {
            if (id < 0)
            {
                return new
                {
                    success = false,
                    message = "Geçersiz Id"
                };
            }
            repo.RolRepository.RolSil(id);
            return new
            { success = true };
        }


    }
}
