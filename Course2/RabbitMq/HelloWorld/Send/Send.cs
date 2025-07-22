using System;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Sender
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "admin",
                Password = "admin123"
            };
            await using var connection = await factory.CreateConnectionAsync();
            await using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: "ItRun", durable: false, exclusive: false, autoDelete: false,
                arguments: null);

            while (true)
            {
                Console.WriteLine("Enter your name:");
                var name = Console.ReadLine(); 
                string message = $"Hello {name}!";
                var body = Encoding.UTF8.GetBytes(message);

                await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "ItRun", body: body);
                Console.WriteLine($" [x] Sent {message}");
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
