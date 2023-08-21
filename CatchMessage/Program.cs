



using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace CatchMessage
{
    public class Program
    {

        static void Main(string[] args)
        {   //baglantı olusturma
            var factory = new ConnectionFactory();

            factory.Uri = new Uri("amqps://oeitnquj:Pypfoc8bx2BWLsFaKVLCEdS90YIRiftK@rattlesnake.rmq.cloudamqp.com/oeitnquj");

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    // Mesajı yakalamak istediğimiz kuyruğu belirtiyoruz
                    channel.QueueDeclare(queue: "mesaj_kuyrugu",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    // Tüketici oluşturuyoruz
                    var consumer = new EventingBasicConsumer(channel);

                    // Mesaj alındığında yapılacak işlemi tanımlıyoruz
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine("Gelen Mesaj: {0}", message);
                    };

                    // Tüketiciyi başlatıyoruz
                    channel.BasicConsume(queue: "mesaj_kuyrugu",
                                         autoAck: true,
                                         consumer: consumer);

                    Console.WriteLine("Mesajları dinliyorum...");
                    Console.ReadLine();
                }
            }
        }


    }
}
