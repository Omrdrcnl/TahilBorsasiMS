﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TahilBorsa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : BaseController
    {

        public DistrictController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
            this.repo = repo;
        }

        // GET: api/<DistrictController>
        [HttpGet("TumIlceler")]
        public dynamic TumIlceler()
        {
            List<tblDistrict> item = repo.DistrictRepository.FindAll().ToList<tblDistrict>();
            return new
            {
                success = true,
                data = item
            };
        }

        [HttpGet("IllerinIlçeleri")]
        public dynamic DistrictsByCity(int ilPlaka)
        {
            List<tblDistrict> items = repo.DistrictRepository.DistrictsByCity(ilPlaka).ToList();

            return new
            {
                success = true,
                data = items
            };

        }
       
    }
}
