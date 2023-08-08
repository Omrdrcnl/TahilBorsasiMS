using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            List<tblFarmer> items = repo.FarmerRepository
                .FindAll()
                .Include(farmer => farmer.tblAddress)
                  .ThenInclude(address => address.tblDistrict)
                .ThenInclude(district => district.tblCity)
                .ToList();

            var mappedItems = items.Select(farmer => new
            {
                Id = farmer.Id,
                FirstName = farmer.FirstName,
                LastName = farmer.LastName,
                IdentityNo = farmer.IdentityNo,
                BirthDate = farmer.BirthDate,
                Contact = farmer.Contact,
                tblAddress = new
                {
                    tblCityId = farmer.tblAddress.tblCityId,
                    tblDistrictId = farmer.tblAddress.tblDistrictId,
                    Neighborhood = farmer.tblAddress.NeighborhoodName,
                    FullAddress = farmer.tblAddress.FullAddress,

                    tblCityName = farmer.tblAddress.tblDistrict.tblCity.Name,
                    tblDistrictName = farmer.tblAddress.tblDistrict.Name,

                }
            });

            return new
            {
                success = true,
                data = mappedItems
            };
        }


        [HttpGet("{farmerId}")]
        public dynamic Get(int farmerId)
        {
            tblFarmer item = repo.FarmerRepository.FindByCondition(x => x.Id == farmerId).FirstOrDefault();

            return new
            {
                success = true,
                data = item
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
                    Id = json.tblAddresId,
                    tblCityId = json.tblAddress.tblCityId,
                    tblDistrictId = json.tblAddress.tblDistrictId,
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

        [HttpDelete("{farmerId}")]
        public dynamic Delete(int farmerId)
        {
            repo.ProductRepository.Delete(farmerId);
            return new { success = true };

        }
    }
}
