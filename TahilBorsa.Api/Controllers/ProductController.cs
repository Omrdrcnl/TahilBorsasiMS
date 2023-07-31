using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using TahilBorsa.Repository;
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

        [HttpGet("TumUrunler")]
        public dynamic TumUrunler()
        {

            List<tblProduct> items;
            if (!cache.TryGetValue("TumUrunler", out items))
            {
                items = repo.ProductRepository.FindAll().ToList<tblProduct>();
                cache.Set("TumUrunler", items, DateTimeOffset.Now.AddHours(120));
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

        [HttpPost("UrunEkle")]
        public dynamic AddProduct([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            tblProduct item = new tblProduct()
            {
                Id = json.Id,
                Name = json.Name,
                Information = json.Information,
                Photo = json.Photo,
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
            cache.Remove("TumUrunler");

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
            return new { success = true };
        }
    }
}
