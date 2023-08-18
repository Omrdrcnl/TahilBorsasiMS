using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsaJqeryAjax.Code.Rest
{
    public class FarmerRestClient
    {
        private string BASE_API_URI = "https://localhost:7234/api";

        public dynamic AddFarmer(string FirstName, string LastName, string IdentityNo,
            string Contact, DateTime? BirthDate, string FullAddress, int tblCityId,
            int tblDistrictId, string? NeighborhoodName)
        {
            RestClient client = new RestClient(BASE_API_URI,
                configureSerialization: s => s.UseSystemTextJson(new JsonSerializerOptions { PropertyNamingPolicy = null }));

            RestRequest req = new RestRequest("/Farmer/EkleCiftci", RestSharp.Method.Post);
            req.AddJsonBody(new
            {
                FirstName = FirstName,
                LastName = LastName,
                Id = 0,
                IdentityNo = IdentityNo,
                Contact = Contact,
                BirthDate = BirthDate,
                AddressId = 0,
                tblCityId = tblCityId,
                tblDistrictId = tblDistrictId,
                NeighborhoodName = NeighborhoodName,
                FullAddress = FullAddress


            });

            RestResponse resp = client.Post(req);
            string msg = resp.Content.ToString();
            dynamic result = JObject.Parse(msg);
            return result;
        }
    }
}
