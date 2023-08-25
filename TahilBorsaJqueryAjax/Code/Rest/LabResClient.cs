using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsaJqeryAjax.Code.Rest
{
    public class LabResClient : BaseRestClient
    {

        public dynamic AddLab(int Id,int EntryProductId,
            int NutritionalValue)
        {
        
            RestRequest req = new RestRequest("/Labaratuar/EnterData", RestSharp.Method.Post);

            //**Önemli**Tokeni requestimizin headırına burada ekliyor gönderiyoruz
            req.AddHeader("Authorization", $"Bearer {Repo.Session.Token}");
            req.AddJsonBody(new
            {
                Id = Id,
                NutritionalValue = NutritionalValue,
                EntryProductId = EntryProductId,
                Process = false
            });

            RestResponse resp = client.Post(req);
            string msg = resp.Content.ToString();
            dynamic result = JObject.Parse(msg);
            return result;
        }

     
    }
}
