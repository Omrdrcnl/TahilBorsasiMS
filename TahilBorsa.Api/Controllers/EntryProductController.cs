﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryProductController : BaseController
    {
        public EntryProductController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
            this.repo = repo;
        }

        [HttpGet("GirisYapanUrunler")]
        public dynamic AllEntryProduct()
        {
            List<tblEntryProduct> tblEntryProducts = repo.EntryProductRepository.FindAll().ToList();
            return new
            {
                success = true,
                data = tblEntryProducts
            };
        }

        [HttpPost("UrunGirisYap")]
        public dynamic AddEntryProduct([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            tblEntryProduct item = new tblEntryProduct()
            {
                Id = json.Id,
                tblProductId = json.ProductId,
                tblFarmerId = json.FarmerId,
                Quantity = json.Quantity,
                DateTime = DateTime.Now,
                Process = false
            };
            if (item.Id > 0)
            {
                repo.EntryProductRepository.Update(item);
            }
            else
            {
                repo.EntryProductRepository.Create(item);
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
