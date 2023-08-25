using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsaJqeryAjax.Code.Rest
{
    public class TradesmanRestClient: BaseRestClient
    {

        public dynamic AddTradesman(int Id,string FirstName, string LastName, string IdentityNo,
            string Contact, DateTime? BirthDate, int AddressId, string FullAddress, int tblCityId,
            int tblDistrictId, string? NeighborhoodName)
        {

            RestRequest req = new RestRequest("/Tradesman/AddTradesman", RestSharp.Method.Post);

            //**Önemli**Tokeni requestimizin headırına burada ekliyor gönderiyoruz
            req.AddHeader("Authorization", $"Bearer {Repo.Session.Token}");
            req.AddJsonBody(new
            {
                FirstName = FirstName,
                LastName = LastName,
                Id = Id,
                IdentityNo = IdentityNo,
                Contact = Contact,
                BirthDate = BirthDate,
                AddressId = AddressId,
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
