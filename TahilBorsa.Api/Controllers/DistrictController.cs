using Microsoft.AspNetCore.Mvc;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TahilBorsa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private RepositoryWrapper repo;

        public DistrictController(RepositoryWrapper repo)
        {
            this.repo = repo;
        }

        // GET: api/<DistrictController>
        [HttpGet("TumIlceler")]
        public dynamic TumIlceler()
        {
            List<District> item = repo.DistrictRepository.FindAll().ToList<District>();
            return new
            {
                success = true,
                data = item
            };
        }

        // GET api/<DistrictController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DistrictController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DistrictController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DistrictController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
