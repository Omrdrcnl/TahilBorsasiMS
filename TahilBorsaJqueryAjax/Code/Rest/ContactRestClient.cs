using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;

namespace TahilBorsaJqeryAjax.Code.Rest
{
    public class ContactRestClient : BaseRestClient
    {
        

        public dynamic Contact(int Id,string Name, string Mail, string Subject, string Message,
            bool? Archive, bool? Deleted, bool? Spam, bool? Important, bool Process)
        {
           

            RestRequest req = new RestRequest("/Contact/SendMessage", RestSharp.Method.Post);

            //**Önemli**Tokeni requestimizin headırına burada ekliyor gönderiyoruz
            req.AddHeader("Authorization", $"Bearer {Repo.Session.Token}");
            req.AddJsonBody(new
            {
                Id = Id,
                Name = Name,
                Mail = Message,
                Message = Subject,
                Subject = Mail,
                Archive = Archive,
                Deleted = Deleted,
                Spam = Spam,
                Important = Important,
                Process = Process
            });

            RestResponse resp = client.Post(req);
            string msg = resp.Content.ToString();
            dynamic result = JObject.Parse(msg);
            return result;
        }

        public dynamic GetComeInMessage()
        {
            RestRequest req = new RestRequest("/Contact/ComeIn", Method.Get);
            RestResponse res = client.Get(req);
            string msg = res.Content.ToString();

            dynamic result = JObject.Parse(msg);
            return result;
        }

        public dynamic GetSpam()
        {
            RestRequest req = new RestRequest("/Contact/Spam", Method.Get);
            RestResponse res = client.Get(req);
            string msg = res.Content.ToString();

            dynamic result = JObject.Parse(msg);
            return result;
        }

        public dynamic GetArchive()
        {
            RestRequest req = new RestRequest("/Contact/Archive", Method.Get);
            RestResponse res = client.Get(req);
            string msg = res.Content.ToString();

            dynamic result = JObject.Parse(msg);
            return result;
        }

        public dynamic GetDeleted()
        {
            RestRequest req = new RestRequest("/Contact/Deleted", Method.Get);
            RestResponse res = client.Get(req);
            string msg = res.Content.ToString();

            dynamic result = JObject.Parse(msg);
            return result;
        }

        public dynamic GetImportant()
        {
            RestRequest req = new RestRequest("/Contact/Important", Method.Get);
            RestResponse res = client.Get(req);
            string msg = res.Content.ToString();

            dynamic result = JObject.Parse(msg);
            return result;
        }

        public dynamic GetContact()
        {
            RestRequest req = new RestRequest("/Contact/AllContact", Method.Get);
            RestResponse res = client.Get(req);
            string msg = res.Content.ToString();

            dynamic result = JObject.Parse(msg);
            return result;
        } 
        
        public dynamic ReadMessage(int id)
        {
            RestRequest req = new RestRequest("/Contact/ReadMessage/" + id, Method.Get);
            RestResponse res = client.Get(req);
            string msg = res.Content.ToString();

            dynamic result = JObject.Parse(msg);
            return result;
        }


    }
}
