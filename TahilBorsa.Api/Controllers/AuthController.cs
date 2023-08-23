using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TahilBorsa.Repository;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }
        [HttpPost("Login")]
        public dynamic Login([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            string username = json.Username;
            string password = json.Password;

            //json tokenın authorize işlemlerini aşagıda yapıyoruz
            tblUser item = repo.UserRepository.FindByCondition(s => s.Username == username && s.Password == password).FirstOrDefault<tblUser>();

            if(item!= null)
            {
                tblRol rol = repo.RolRepository.FindByCondition(r => r.Id == item.tblRolId).SingleOrDefault<tblRol>();

                Dictionary<string, object> claims = new Dictionary<string, object>();

                claims.Add(ClaimTypes.Role, rol.Name);

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes("TahilBorsasiİlkProjeTokenOlusturmaStringi");

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddMinutes(100),

                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature),
                    Claims = claims
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return new
                {
                    success = true,
                    data = tokenHandler.WriteToken(token),
                    rol = rol?.Name
                };

            }
            else
            {
                return new
                {
                    success = false,
                    message = "Kullanıcı adı veya şifre hatalı"
                };
            }
        }
    }
}
