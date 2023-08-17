using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;

namespace TahilBorsaJqeryAjax.Code.Rest
{
    public class ContactRestClient
    {
        private string BASE_API_URI = "https://localhost:7234/api";

        public dynamic Contact(string Name, string Mail, string Subject, string Message)
        {
            RestClient client = new RestClient(BASE_API_URI,
                configureSerialization: s => s.UseSystemTextJson(new JsonSerializerOptions { PropertyNamingPolicy = null }));

            RestRequest req = new RestRequest("/Contact/SendMessage", RestSharp.Method.Post);
            req.AddJsonBody(new
            {
                Name = Name,
                Mail = Message,
                Message = Subject,
                Subject = Mail
            });

            RestResponse resp = client.Post(req);
            string msg = resp.Content.ToString();
            dynamic result = JObject.Parse(msg);
            return result;
        }
    }
}
