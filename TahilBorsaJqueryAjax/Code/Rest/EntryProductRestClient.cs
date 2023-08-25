using Newtonsoft.Json.Linq;
using NuGet.Common;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;

namespace TahilBorsaJqeryAjax.Code.Rest
{
    public class EntryProductRestClient : BaseRestClient
    {

        public dynamic AddEntryProduct(int FarmerId, DateTime DateTime,
            int ProductId)
        {

            RestRequest req = new RestRequest("/EntryProduct/Enter", RestSharp.Method.Post);
            //**Önemli**Tokeni requestimizin headırına burada ekliyor gönderiyoruz
            req.AddHeader("Authorization", $"Bearer {Repo.Session.Token}");


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
