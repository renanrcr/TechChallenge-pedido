namespace Infrastructure.RabbitMQ
{
    public interface IRabbitPublish
    {
        bool BasicPublishPedidoCriar(object messageString);
    }
}
