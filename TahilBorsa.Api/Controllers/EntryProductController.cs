using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;
using TahilBorsaMS.Models.Views;

namespace TahilBorsa.Api.Controllers
{
    [Authorize(Roles = "admin, person")]

    [Route("api/[controller]")]
    [ApiController]
    public class EntryProductController : BaseController
    {
        public EntryProductController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
            this.repo = repo;
        }

        [HttpGet("EnterList")]
        public dynamic AllEntryProduct()
        {
            List<V_EntryProductList> tblEntryProducts = repo.EntryProductRepository.GetEntryProductList();
            return new
            {
                success = true,
                data = tblEntryProducts
            };
        }

        [HttpPost("Enter")]
        public dynamic AddEntryProduct([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            tblEntryProduct item = new tblEntryProduct()
            {
                Id = json.Id,
                tblProductId = json.tblProductId,
                tblFarmerId = json.tblFarmerId,
                DateTime = json.DateTime,
                Process = json.Process
            };
            if (item.Id > 0)
            {
                repo.EntryProductRepository.Update(item);
            }
            else
            {
                var farmer = repo.FarmerRepository.FindByCondition(x => x.Id == item.tblFarmerId).FirstOrDefault();
                if(farmer != null && farmer.Id !=0)
                {
                    repo.EntryProductRepository.Create(item);

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
                        message = "Bu kayıt Numarasında Bir Çiftçi Bulunmamaktadır."
                    };
                }
            }

            repo.SaveChanges();
           

            return new
            {
                success = true,
                data = item
            };
        }
    }
}
