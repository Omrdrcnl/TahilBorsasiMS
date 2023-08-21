using RabbitMQ.Client;
using System;
using System.Text;


class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 10; i++)
        {
            SendMessage();
        }
    }
    
    public static void SendMessage()
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
                string message = "Merhaba, bu bir test mesajıdır!";
                var body = Encoding.UTF8.GetBytes(message);

                // Mesajı kuyruğa gönderin
                channel.BasicPublish(exchange: "",
                                     routingKey: "mesaj_kuyrugu",
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine("Mesaj gönderildi: {0}", message);
            }
        }


        Console.ReadLine();
    }
}

