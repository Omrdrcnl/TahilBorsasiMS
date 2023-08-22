using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Mesajınızı Giriniz: ");
        string message = Console.ReadLine();

        if(string.IsNullOrWhiteSpace(message))
        {
            Console.WriteLine("Lütfen Geçerli Bir mesaj giriniz..!");
            return;
        }

        List<string> numbers = await GetNumbersFromApi();

        foreach(var number in numbers)
        {
            SendMessage(message, number);
        }

        Console.WriteLine("Mesajlar gönderildi");
        
    }

    public static void SendMessage(string message, string number)
    {
        // RabbitMQ sunucu adresini ve bağlantı bilgilerini ayarlayın
        var factory = new ConnectionFactory();


        factory.Uri = new Uri("amqps://oeitnquj:Pypfoc8bx2BWLsFaKVLCEdS90YIRiftK@rattlesnake.rmq.cloudamqp.com/oeitnquj");
        // RabbitMQ bağlantısı oluşturun
        using (var connection = factory.CreateConnection())
        {
            // Kanal oluşturun
            using (var channel = connection.CreateModel())
            {
                // Mesaj göndermek için kuyruk oluşturun
                channel.QueueDeclare(queue: "mesaj_kuyrugu",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                // Gönderilecek mesajı oluşturun
                string fullMessage = $"{message} Telefon Numarası: {number}";
                var body = Encoding.UTF8.GetBytes(fullMessage);

                // Mesajı kuyruğa gönderin
                channel.BasicPublish(exchange: "",
                                     routingKey: "mesaj_kuyrugu",
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine("Mesaj gönderildi: {0}", fullMessage);
            }
        }


        Console.ReadLine();
    }


    public static async Task<List<string>> GetNumbersFromApi()
    {
        using (HttpClient client = new HttpClient())
        {
            string apiUrl = "https://localhost:7234/api/Tradesman/GetNumbers";

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if(response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();

                //Apiden gelen verileri çöz
                var responseData = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);

                if (responseData.success)
                {
                    List<string> numbers = responseData.data;
                    return numbers;
                }
                else
                {
                    Console.WriteLine("Api çağrısı Başarız.");
                    return new List<string>();
                }
            }
            else
            {
                Console.WriteLine("Api çagrısı başarız", response.StatusCode);
                return new List<string>();
            }
        }
    }
}
public class ApiResponse
{
    public bool success { get; set; }
    public List<string> data { get; set; }
}
