using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerController : BaseController
    {

        public FarmerController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
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

        [HttpPost("CiftciEkle")]
        public dynamic AddFarmer([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            tblFarmer item = new tblFarmer()
            {
                Id = json.Id,
                FirstName = json.FirstName,
                LastName = json.LastName,
                BirthDate = json.BirthDate,
                tblAddress = new tblAddress()
                {
                    Id=json.tblAddresId,
                    tblCityId = json.tblAddress.CityId,
                    tblDistrictId = json.tblAddress.DistrictId,
                    NeighborhoodName = json.tblAddress.NeighborhoodName,
                    FullAddress = json.tblAddress.FullAddress,
                },
                Contact = json.Contact,
                IdentityNo = json.IdentityNo,
            };
            if (item.Id > 0)
            {
                repo.FarmerRepository.Update(item);
            }
            else
            {
                repo.FarmerRepository.Create(item);
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
