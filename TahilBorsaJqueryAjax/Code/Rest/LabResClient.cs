using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsaJqeryAjax.Code.Rest
{
    public class LabResClient
    {
        private string BASE_API_URI = "https://localhost:7234/api";

        public dynamic AddLab(int EntryProductId,
            int NutritionalValue)
        {
            RestClient client = new RestClient(BASE_API_URI,
                configureSerialization: s => s.UseSystemTextJson(new JsonSerializerOptions { PropertyNamingPolicy = null }));

            RestRequest req = new RestRequest("/Labaratuar/EnterData", RestSharp.Method.Post);
            req.AddJsonBody(new
            {
                Id = 0,
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
