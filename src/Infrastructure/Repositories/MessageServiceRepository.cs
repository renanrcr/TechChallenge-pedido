using Domain.Adapters;
using Infrastructure.RabbitMQ;
using RabbitMQ.Client;

namespace Infrastructure.Repositories
{
    public class MessageServiceRepository : RabbitPublish, IMessageService
    {
        public MessageServiceRepository(IModel channel) : base(channel) { }

        public bool Enqueue(object messageString) => BasicPublishPedidoCriar(messageString);
    }
}
