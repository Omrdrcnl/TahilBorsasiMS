using Newtonsoft.Json;
using RestSharp;

namespace TahilBorsaJqeryAjax.Code.Rest
{
    public class SaleRestClient
    {


        public dynamic? GetProductBulletin()
        {
            // RestClient oluştur
            var client = new RestClient("https://localhost:7234/api");

            // GET isteği oluştur
            var request = new RestRequest("Product/Bulletin", Method.Get);

            // İstek gönder ve cevabı al
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // JSON verisini ayrıştır
                var jsonContent = response.Content;
                var productList = JsonConvert.DeserializeObject<List<Product>>(jsonContent);

                return productList; // JSON dizisi olarak ayrıştırılmış veriyi geri döndür
            }

            return null;
        }
    }

    public class Product
    {
        public string date { get; set; }
        public string productName { get; set; }
        public decimal totalBasePrice { get; set; }
        public decimal actualPrice { get; set; }
    }
}
