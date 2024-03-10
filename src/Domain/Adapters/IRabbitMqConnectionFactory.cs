using RabbitMQ.Client;

namespace Domain.Adapters
{
    public interface IRabbitMqConnectionFactory
    {
        IModel GetConnectionQueuePedidoCriar();
    }
}
