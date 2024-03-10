using Domain.Adapters;
using RabbitMQ.Client;

namespace Infrastructure.Tests.Repositories
{
    public class RabbitServerMock : IRabbitMqConnectionFactory
    {
        public IModel GetConnectionQueuePedidoCriar()
        {
            Console.WriteLine("conectando com o RabbitMQ...");

            var connectionfactory =
                new ConnectionFactory
                {
                    HostName = "rabbitmq",
                    Port = 5672,
                    UserName = "guest",
                    Password = "guest",
                };

            IConnection connection = connectionfactory.CreateConnection();

            IModel _channel = connection.CreateModel();

            _channel.QueueDeclare(queue: "pedido_criar",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            return _channel;
        }
    }
}
