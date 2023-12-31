﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System.Linq;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Controllers
{
    [Authorize(Roles ="admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
            this.repo = repo;
        }


        [HttpGet("AllUsers")]
        public dynamic TumKullanicilar()
        {
            List<tblUser> item = repo.UserRepository.FindAll().Include(x => x.tblRol).ToList();
            return new
            {
                success = true,
                data = item
            };
        }

        [HttpGet("{Id}")]
        public dynamic Get(int id)
        {
            tblUser item = repo.UserRepository.FindByCondition(a => a.Id == id).SingleOrDefault<tblUser>();
            return new
            {
                success = true,
                data = item
            };
        }

        [HttpPost("AddUser")]
        public dynamic AddUser([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            tblUser item = new tblUser()
            {
                Id = json.Id,
                Username = json.Username,
                Password = json.Password,
                FirstName = json.FirstName,
                LastName = json.LastName,
                tblRolId = json.RolId,
            };

            if (item.Id > 0)
            {
                repo.UserRepository.Update(item);
            }
            else
            {
                repo.UserRepository.Create(item);
            }

            repo.SaveChanges();

            return new
            {
                success = true,
                data = item
            };
        }

        [HttpDelete("{Id}")]
        public dynamic Delete(int id)
        {
            if (id < 0)
            {
                return new
                {
                    success = false,
                    message = "Geçersiz Id"
                };
            }
            repo.UserRepository.Sil(id);
            return new
            { success = true };
        }
    }
}
