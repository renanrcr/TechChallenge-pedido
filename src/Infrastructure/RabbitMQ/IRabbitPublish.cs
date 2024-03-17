using RabbitMQ.Client;

namespace Infrastructure.RabbitMQ
{
    public interface IRabbitPublish
    {
        bool BasicPublishPedidoCriar(IModel channel, object messageString);
    }
}
