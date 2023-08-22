using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;
using TahilBorsaMS.Models.Classes;

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

        [HttpGet("AllFarmers")]
        public dynamic AllFarmers()
        {
            List<tblFarmer> items;

            if (!cache.TryGetValue("AllFarmers", out items))
            {
                items = repo.FarmerRepository
                .FindAll()
                .Include(farmer => farmer.tblAddress)
                .ThenInclude(address => address.tblDistrict)
                .ThenInclude(district => district.tblCity)
                .ToList();

                cache.Set("AllFarmers", items, DateTimeOffset.UtcNow.AddMinutes(100));
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


        [HttpPost("AddFarmer")]
        public dynamic AddFarmer([FromBody] CiftciEkleRequestModel request)
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
                Id = request.Id,
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
            if (newFarmer.Id > 0)
            {
                repo.FarmerRepository.Update(newFarmer);

            }
            else
            {
                var identy = repo.FarmerRepository.FindByCondition(x => x.IdentityNo == newFarmer.IdentityNo).FirstOrDefault();
                if (identy == null)
                {
                    repo.FarmerRepository.Create(newFarmer);
                    repo.SaveChanges();

                    //CACHEDEN SİL
                    cache.Remove("AllFarmers");

                    return new
                    {
                        success = true,
                        data = newFarmer
                    };
                }
                else
                {
                    return new
                    {
                        success = false,
                        message = "Aynı Kimlik numarasına kayıtlı bir Çiftçi bulunmaktadır."
                    };
                }

            }

            repo.SaveChanges();

            //CACHEDEN SİL
            cache.Remove("AllFarmers");

            return new
            {
                success = true,
                data = newFarmer
            };



        }

        [HttpDelete("{farmerId}")]
        public dynamic Delete(int farmerId)
        {
            repo.FarmerRepository.Delete(farmerId);
            return new { success = true };

        }
    }
}
