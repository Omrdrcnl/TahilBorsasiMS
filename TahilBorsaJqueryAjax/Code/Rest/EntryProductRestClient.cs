using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;

namespace TahilBorsaJqeryAjax.Code.Rest
{
    public class EntryProductRestClient
    {
        private string BASE_API_URI = "https://localhost:7234/api";

        public dynamic AddEntryProduct(int FarmerId, DateTime DateTime,
            int ProductId)
        {
            RestClient client = new RestClient(BASE_API_URI,
                configureSerialization: s => s.UseSystemTextJson(new JsonSerializerOptions { PropertyNamingPolicy = null }));

            RestRequest req = new RestRequest("/EntryProduct/Enter", RestSharp.Method.Post);
            req.AddJsonBody(new
            {
                Id = 0,
                tblProductId = ProductId,
                tblFarmerId = FarmerId,
                DateTime = DateTime,
                Process = false
            });

            RestResponse resp = client.Post(req);
            string msg = resp.Content.ToString();
            dynamic result = JObject.Parse(msg);
            return result;
        }
    }
}
