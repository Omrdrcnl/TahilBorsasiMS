using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;
using TahilBorsaMS.Models.Views;

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

        [HttpGet("Readylab")]
        public dynamic ReadyLab()
        {
            List<V_EntryProductList> items = repo.LabDataRepository.GetReadyLabList();

            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet("LabList")]
        public dynamic LabList()
        {
            List<V_LabList> items = repo.LabDataRepository.GetLabList();

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

            //Lab işlem sırasından kaldırmak için processi 1'e çek
            int entryProductId = json.EntryProductId;

            var entryProduct = repo.EntryProductRepository.FindByCondition(e => e.Id == entryProductId).FirstOrDefault();
            if (entryProduct != null)
            {
                entryProduct.Process = true;

                repo.EntryProductRepository.Update(entryProduct);
                repo.SaveChanges();
            }

            tblLabData item = new tblLabData()
            {
                Id = json.Id,
                tblEntryProductId = json.EntryProductId,
                Process = json.Process,
                NutritionalValue = json.NutritionalValue,

            };


            repo.LabDataRepository.Create(item);
            repo.SaveChanges();

            //Satışta sıraya koymak içinde satış verisi olustur processi 0'a çek

            tblSale sale = new tblSale()
            {
                Process = false,
                tblEntryProductId = (int)json.EntryProductId,
                tblLabDataId = item.Id  // Önce oluşturulan tblLabData'nın Id'sini kullanın
            };

            if (sale.tblLabDataId > 0)
            {
                repo.SaleRepository.Create(sale);
                repo.SaveChanges();
            }



            return new
            {
                success = true,
                data = item
            };

        }


    }
}
