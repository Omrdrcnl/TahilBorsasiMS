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
    public class LabaratuarController : BaseController
    {

        public LabaratuarController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
            this.repo = repo;
        }

        [HttpGet("TumLabaratuarVeriler")]
        public dynamic AllLabData()
        {
            List<tblAddress> item = repo.AddressRepository.FindAll().ToList();

            return new
            {
                success = true,
                data = item
            };
        }

        [HttpGet("VeriGirişineHazırUrunler")]
        public dynamic ReadySale()
        {
            List<tblEntryProduct> items = repo.EntryProductRepository.FindByCondition(x => x.Process == false).ToList<tblEntryProduct>();
            return new
            {
                success = true,
                data = items
            };
        }

        [HttpPost("VeriGir")]
        public dynamic AddSale([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());


            tblLabData item = new tblLabData()
            {
                Process = true,
                NutritionalValue = json.NutritionalValue,

            };

            if(item != null) {

                repo.LabDataRepository.Update(item);

                tblSale sale = new tblSale()
                {
                    Process = false,
                    tblEntryProductId = (int)json.tblEntryProductId,
                    tblLabDataId = json.Id,
                };
                if(sale != null)
                {
                    repo.SaleRepository.Create(sale);
                    repo.SaveChanges();
                    return new
                    {
                        success = true,
                        data = sale
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
