using Domain.Adapters;
using RabbitMQ.Client;
using System.Text;

namespace Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IModel _channel;

        public MessageService()
        {
            Console.WriteLine("conectando com o RabbitMQ...");

            ConnectionFactory connectionfactory = 
                new ConnectionFactory
                { 
                    HostName = "rabbitmq", 
                    Port = 5672,
                    UserName = "guest",
                    Password = "guest",
                };

            IConnection connection = connectionfactory.CreateConnection();

            _channel = connection.CreateModel();

            _channel.QueueDeclare(queue: "pedido_criar",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
        }

        public bool Enqueue(object messageString)
        {
            var body = Encoding.UTF8.GetBytes("server processed " + messageString);

            _channel.BasicPublish(exchange: "",
                                routingKey: "pedido_criar",
                                basicProperties: null,
                                body: body);

            Console.WriteLine(" [x] Published {0} to RabbitMQ", messageString);

            

            return true;
        }
    }
}
