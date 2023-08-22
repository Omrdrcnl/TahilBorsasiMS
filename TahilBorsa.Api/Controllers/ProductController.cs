using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using TahilBorsa.Repository;
using TahilBorsaMS.Controllers;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {

        public ProductController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
            this.repo = repo;
        }

        [HttpGet("AllProducts")]
        public dynamic AllProducts()
        {

            List<tblProduct> items;
            if (!cache.TryGetValue("AllProducts", out items))
            {
                items = repo.ProductRepository.FindAll().ToList<tblProduct>();
                cache.Set("AllProducts", items, DateTimeOffset.Now.AddHours(120));
            }
            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet("{Id}")]
        public dynamic Get(int id)
        {
            tblProduct item = repo.ProductRepository.FindByCondition(a => a.Id == id).SingleOrDefault<tblProduct>();
            return new
            {
                success = true,
                data = item
            };
        }

        [HttpGet("Bulletin")]
        public dynamic GetBulletin(DateTime? selectedDate)
        {
            var item = repo.ProductRepository.GetBulletins();

            // Varsayılan olarak bugünkü tarihi kullanmak için:
            if (!selectedDate.HasValue)
            {
                selectedDate = DateTime.Today;
            }

            // Seçilen tarih için günün başlangıcı ve bitişi
            DateTime startDate = selectedDate.Value.Date;
            DateTime endDate = startDate.AddDays(1).AddTicks(-1);

            //Yeni bir sınıf olusturup value degerini oraya aktarıyoruz. Liste halınde de bunu viewde cekıyoruz.
            var groupedSales = item
                .Where(s => s.Date >= startDate && s.Date <= endDate)
                .GroupBy(s => new { s.ProductName, s.Date, s.Photo })
                .Select(group => new GroupedSaleViewModel
                {
                    ProductName = group.Key.ProductName,
                    SaleDate = (DateTime)group.Key.Date,
                    TotalQuantity = group.Sum(s => s.Quantity),
                    TotalActualPrice = group.Max(s => s.ActualPrice),
                    TotalBasePrice = group.Min(s => s.ActualPrice),
                    Photo = group.Key.Photo
                })
                .ToList();
            return new
            {
                success = true,
                data = groupedSales
            };
        }

        [HttpPost("AddProduct")]
        public dynamic AddProduct([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            tblProduct item = new tblProduct()
            {
                Id = json.Id,
                Name = json.Name,
                Information = json.Information,
                Photo = json.Photo,
                Factor = json.Factor,
            };
            if (item.Id > 0)
            {
                repo.ProductRepository.Update(item);
            }
            else
            {
                repo.ProductRepository.Create(item);
            }

            repo.SaveChanges();
            cache.Remove("AllProducts");

            return new
            {
                success = true,
                data = item
            };
        }

        [HttpDelete("{id}")]
        public dynamic Delete(int id)
        {
            repo.ProductRepository.Delete(id);
            cache.Remove("AllProducts");

            return new { success = true };
        }
    }
}
