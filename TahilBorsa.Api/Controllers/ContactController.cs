using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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


        [HttpGet("AllContact")]
        public dynamic AllMessages()
        {
            List<tblContact> item = repo.ContactRepository.FindAll().ToList<tblContact>();
            return new
            {
                success = true,
                data = item
            };
        }

        [HttpGet("ComeIn")]
        public dynamic ComeIn()
        {
            List<tblContact> items = repo.ContactRepository.
                FindByCondition(x => x.Process == false).ToList<tblContact>();
            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet("Archive")]
        public dynamic Archive()
        {
            List<tblContact> items = repo.ContactRepository.
                FindByCondition(x => x.Archive == true).ToList<tblContact>();
            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet("Deleted")]
        public dynamic Deleted()
        {
            List<tblContact> items = repo.ContactRepository.
                FindByCondition(x => x.Deleted == true).ToList<tblContact>();
            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet("Spam")]
        public dynamic Spam()
        {
            List<tblContact> items = repo.ContactRepository.
                FindByCondition(x => x.Spam == true).ToList<tblContact>();
            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet("Important")]
        public dynamic Important()
        {
            List<tblContact> items = repo.ContactRepository.
                FindByCondition(x => x.Important == true).ToList<tblContact>();
            return new
            {
                success = true,
                data = items
            };
        }

        [HttpPost("SendMessage")]
        public dynamic SendMessage([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());



            //json tokenın authorize işlemlerini aşagıda yapıyoruz
            tblContact item = new tblContact()
            {
                Id = 0,
                Name = json.Name,
                Mail = json.Mail,
                Message = json.Message,
                Subject = json.Subject,
                Process = true,
                Date = DateTime.Today,
            };

            if (item != null)
            {

                repo.ContactRepository.Create(item);
                repo.SaveChanges();

                return new
                {
                    success = true,
                    data = item
                };

            }
            else
            {
                return new
                {
                    success = false,
                    message = "Lütfen İlgili Alanları doldurunuz"
                };
            }
        }
    }
}
