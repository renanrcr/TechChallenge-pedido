using RabbitMQ.Client;

namespace Infrastructure.RabbitMQ
{
    public interface IConnectionFactory
    {
        ConnectionFactory Get();
    }
}
