using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;
using TahilBorsaMS.Models.Entity;

namespace TahilBorsaJqeryAjax.Code.Rest
{
    public class LabResClient : BaseRestClient
    {

        public dynamic AddLab(int EntryProductId,
            int NutritionalValue)
        {
        
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
