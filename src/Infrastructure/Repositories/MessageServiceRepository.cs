using Domain.Adapters;
using RabbitMQ.Client;
using Infrastructure.RabbitMQ;

namespace Infrastructure.Repositories
{
    public class MessageServiceRepository : IMessageServiceRepository
    {
        private readonly IRabbitPublish _rabbitPublish;
        private readonly IModel _channel;
        public MessageServiceRepository(RabbitMQ.IConnectionFactory connectionFactory, IRabbitPublish rabbitPublish) 
        {
            _rabbitPublish = rabbitPublish;

            using IConnection connection = connectionFactory.Get().CreateConnection();
            using IModel model = connection.CreateModel();

            model.QueueDeclare(queue: "pedido_produzir",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            _channel = model;
        }

        public bool Enqueue(object messageString) => _rabbitPublish.BasicPublishPedidoCriar(_channel, messageString);
    }
}
