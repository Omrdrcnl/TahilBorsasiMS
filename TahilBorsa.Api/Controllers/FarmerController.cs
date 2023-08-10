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
            List<tblFarmer> items;

            if (!cache.TryGetValue("TumCiftciler", out items))
            {
                items = repo.FarmerRepository
                .FindAll()
                .Include(farmer => farmer.tblAddress)
                  .ThenInclude(address => address.tblDistrict)
                .ThenInclude(district => district.tblCity)
                .ToList();

                cache.Set("TumCiftciler", items, DateTimeOffset.UtcNow.AddMinutes(100));
            }

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

            // Farmer verisini veritabanından çek
            tblFarmer item = repo.FarmerRepository.FindByCondition
                (x => x.Id == farmerId).Include(x => x.tblAddress)
                .FirstOrDefault();

            if (item != null)
            {
                return new
                {
                    success = true,
                    data = new
                    {
                        id = item.Id,
                        birthDate = item.BirthDate,
                        firstName = item.FirstName,
                        lastName = item.LastName,
                        identityNo = item.IdentityNo,
                        contact = item.Contact,
                        tblAddress = new
                        {
                            AddressId = item.tblAddress.Id,
                            CityId = item.tblAddress.tblCityId,
                            DistrictId = item.tblAddress.tblDistrictId,
                            neighborhoodName = item.tblAddress.NeighborhoodName,
                            fullAddress = item.tblAddress.FullAddress
                        }
                    }
                };
            }
            else
            {
                return new
                {
                    success = false,
                    message = "Çiftçi bulunamadı"
                };
            }


        }


        [HttpPost("EkleCiftci")]
        public dynamic EkleCiftci([FromBody] CiftciEkleRequestModel request)
        {
            if (request == null)
            {
                return BadRequest("Istek verileri boş.");
            }
            // CiftciEkleRequestModel adında verileri alacagımız formatta bir model olustur
            // Şehir ve ilçe bilgilerini kullanarak nesneleri al
            var city = repo.CityRepository.GetById(request.tblCityId);
            var district = repo.DistrictRepository.GetById(request.tblDistrictId);



            // Çiftçi nesnesini oluştur atamaları yap
            
            var newFarmer = new tblFarmer
            {
                Id = request.FarmerId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                IdentityNo = request.IdentityNo,
                BirthDate = request.BirthDate,
                Contact = request.Contact,
                tblAddress = new tblAddress
                {
                    Id = request.AddressId,
                    tblCityId = city.Id,
                    tblDistrictId = district.Id,
                    NeighborhoodName = request.NeighborhoodName,
                    FullAddress = request.FullAddress
                }
            };

            // Veritabanına ekle
            if (newFarmer.Id  >0)
            {
                repo.FarmerRepository.Update(newFarmer);
                
            }
            else
            {
                repo.FarmerRepository.Create(newFarmer);
                
            }

            repo.SaveChanges();

            //CACHEDEN SİL
            cache.Remove("TumCiftciler");

            return new
            {
                success = true,
                data = newFarmer
            };
        }


        //[HttpPost("CiftciEkle")]
        //public dynamic AddFarmer([FromBody] dynamic model)
        //{
        //    dynamic json = JObject.Parse(model.GetRawText());

        //    tblFarmer item = new tblFarmer()
        //    {
        //        Id = json.Id,
        //        FirstName = json.FirstName,
        //        LastName = json.LastName,
        //        BirthDate = json.BirthDate,
        //        tblAddress = new tblAddress()
        //        {
        //            Id = json.tblAddresId,
        //            tblCityId = json.tblAddress.tblCityId,
        //            tblDistrictId = json.tblAddress.tblDistrictId,
        //            NeighborhoodName = json.tblAddress.NeighborhoodName,
        //            FullAddress = json.tblAddress.FullAddress,
        //        },
        //        Contact = json.Contact,
        //        IdentityNo = json.IdentityNo,
        //    };
        //    if (item.Id > 0 && item.tblAddress.Id >0)
        //    {
        //        repo.FarmerRepository.Update(item);
        //        repo.AddressRepository.Update(item.tblAddress);
        //    }
        //    else
        //    {
        //        repo.FarmerRepository.Create(item);
        //        repo.AddressRepository.Create(item.tblAddress);
        //    }

        //    repo.SaveChanges();

        //    return new
        //    {
        //        success = true,
        //        data = item
        //    };
        //}

        [HttpDelete("{farmerId}")]
        public dynamic Delete(int farmerId)
        {
            repo.FarmerRepository.Delete(farmerId);
            return new { success = true };

        }
    }
}
