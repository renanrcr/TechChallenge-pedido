using RabbitMQ.Client;

namespace Infrastructure.RabbitMQ
{
    public class ConnectionFactoryCreator : IConnectionFactory
    {
        public ConnectionFactory Get()
        {
            return new ConnectionFactory
            {
                HostName = "rabbitmq",
                Port = 5672,
                UserName = "guest",
                Password = "guest",
            };
        }
    }
}