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
    public class TradesmanController : BaseController
    {

        public TradesmanController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
            this.repo = repo;
        }

        [HttpGet("Esnaflar")]
        public dynamic AllTradesman()
        {
            List<tblTradesman> items;

            if (!cache.TryGetValue("Esnaflar", out items))
            {
                items = repo.TradesmanRepository
                .FindAll()
                .Include(t => t.tblAddress)
                .ThenInclude(c => c.tblDistrict)
                    .ThenInclude(d => d.tblCity)
                    .ToList();
                //sacma bir şekide tblCity Tablosuna erişemiyorum


                cache.Set("Esnaflar", items, DateTimeOffset.UtcNow.AddMinutes(100));
            }



            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet("{tradesmanId}")]
        public dynamic Get(int tradesmanId)
        {
            tblTradesman item = repo.TradesmanRepository.FindByCondition(x => x.Id == tradesmanId).FirstOrDefault();

            return new
            {
                success = true,
                data = item
            };
        }

        [HttpPost("EsnafEkle")]
        public dynamic AddTradesman([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            tblTradesman item = new tblTradesman()
            {
                Id = json.Id,
                FirstName = json.FirstName,
                LastName = json.LastName,
                tblAddress = new tblAddress()
                {
                    Id = json.AddressId,
                    tblCityId = json.tblCityId,
                    tblDistrictId = json.tblDistrictId,
                    NeighborhoodName = json.NeighborhoodName,
                    FullAddress = json.FullAddress,

                },
                Contact = json.Contact,
                IdentityNo = json.IdentityNo,
                Birthdate = json.Birthdate,
            };
            if (item.Id > 0)
            {
                repo.TradesmanRepository.Update(item);
            }
            else
            {
                repo.TradesmanRepository.Create(item);
            }

            repo.SaveChanges();

            cache.Remove("Esnaflar");
            return new
            {
                success = true,
                data = item
            };
        }

        [HttpDelete("Delete/{tradesmanId}")]
        public dynamic Delete(int tradesmanId)
        {
            repo.TradesmanRepository.Delete(tradesmanId);

            cache.Remove("Esnaflar");
            return new { success = true };

        }
    }
}
