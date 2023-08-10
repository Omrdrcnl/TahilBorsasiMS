using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System.Linq;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
            this.repo = repo;
        }


        [HttpGet("TumKullanicilar")]
        public dynamic TumKullanicilar()
        {
            List<tblUser> item = repo.UserRepository.FindAll().ToList<tblUser>();
            return new
            {
                success = true,
                data = item
            };
        }

        [HttpGet("{Id}")]
        public dynamic Get(int id)
        {
            tblUser item = repo.UserRepository.FindByCondition(a => a.Id == id).SingleOrDefault<tblUser>();
            return new
            {
                success = true,
                data = item
            };
        }

        [HttpPost("KullaniciEkle")]
        public dynamic AddUser([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            tblUser item = new tblUser()
            {
                Id = json.Id,
                Username = json.Username,
                Password = json.Password,
                FirstName = json.FirstName,
                LastName = json.LastName,
                tblRolId = json.tblRolId,
            };

            if (item.Id > 0)
            {
                repo.UserRepository.Update(item);
            }
            else
            {
                repo.UserRepository.Create(item);
            }

            repo.SaveChanges();

            return new
            {
                success = true,
                data = item
            };
        }

        [HttpDelete("{userId}")]
        public dynamic Delete(int userId)
        {
            repo.UserRepository.Delete(userId);
            return new { success = true };
        }
    }
}
