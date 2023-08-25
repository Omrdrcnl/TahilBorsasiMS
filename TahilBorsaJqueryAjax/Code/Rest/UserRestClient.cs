using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;


namespace TahilBorsaJqeryAjax.Code.Rest
{
    public class UserRestClient : BaseRestClient
    {

        public dynamic Login(string userName, string password)
        {

            RestRequest req = new RestRequest("/Auth/Login", RestSharp.Method.Post);

            //**Önemli**Tokeni requestimizin headırına burada ekliyor gönderiyoruz
            req.AddHeader("Authorization", $"Bearer {Repo.Session.Token}");
            req.AddJsonBody(new
            {
                Username = userName,
                Password = password
            });

            RestResponse resp = client.Post(req);
            string msg = resp.Content.ToString();
            dynamic result = JObject.Parse(msg);
            return result;
        }

      
    }
}
