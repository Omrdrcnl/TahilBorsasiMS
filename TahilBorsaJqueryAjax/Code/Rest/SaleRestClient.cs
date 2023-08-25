using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Reflection.Emit;

namespace TahilBorsaJqeryAjax.Code.Rest
{
    public class SaleRestClient : BaseRestClient
    {

        public dynamic EnterSale(int LabId, int TradesmanId, int EntryId, int SaleId, DateTime Date, decimal ActualPrice,
            decimal BasePrice, int Quantity)
        {
            RestRequest req = new RestRequest("/Sale/EnterSale", RestSharp.Method.Post);

            //**Önemli**Tokeni requestimizin headırına burada ekliyor gönderiyoruz
            req.AddHeader("Authorization", $"Bearer {Repo.Session.Token}");
            req.AddJsonBody(new
            {
                Id = SaleId,
                LabDataId = LabId,
                EntryId = EntryId,
                TradesmanId = TradesmanId,
                ActualPrice = ActualPrice,
                BasePrice = BasePrice,
                Date = Date,
                Quantity = Quantity,
                Process = true
            });

            RestResponse resp = client.Post(req);
            string msg = resp.Content.ToString();
            dynamic result = JObject.Parse(msg);
            return result;
        }
    }


}
