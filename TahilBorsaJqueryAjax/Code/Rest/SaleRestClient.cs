using RestSharp;

namespace TahilBorsaJqeryAjax.Code.Rest
{
    public class SaleRestClient
    {


        public dynamic GetProductBulletin()
        {
            // RestClient oluştur
            var client = new RestClient("https://localhost:7234/api");

            // GET isteği oluştur
            var request = new RestRequest("Product/Bulletin", Method.Get);

            // İstek gönder ve cevabı al
            var response = client.Execute(request);

            // Cevap içeriğini yazdır
            return response;
            
        }

    }
}
