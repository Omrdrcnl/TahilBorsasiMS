using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsaJqeryAjax.Code.Rest
{
    public class FarmerRestClient : BaseRestClient
    {


        public dynamic AddFarmer(int Id, int AddressId, string FirstName, string LastName, string IdentityNo,
            string Contact, DateTime? BirthDate, string FullAddress, int tblCityId,
            int tblDistrictId, string? NeighborhoodName)
        {
            RestRequest req = new RestRequest("/Farmer/AddFarmer", RestSharp.Method.Post);
            //**Önemli**Tokeni requestimizin headırına burada ekliyor gönderiyoruz
            req.AddHeader("Authorization", $"Bearer {Repo.Session.Token}");
            req.AddJsonBody(new
            {
                Id = Id,
                AddressId = AddressId,
                FirstName = FirstName,
                LastName = LastName,

                IdentityNo = IdentityNo,
                Contact = Contact,
                BirthDate = BirthDate,

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
