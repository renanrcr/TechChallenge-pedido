using RabbitMQ.Client;
using System.Text;

namespace Infrastructure.RabbitMQ
{
    public abstract class RabbitPublish : IRabbitPublish
    {
        public IModel _channel;

        protected RabbitPublish(IModel channel) 
        {
            _channel = channel;
            _channel.CriarFilaPedidoCriar();
        }

        public bool BasicPublishPedidoCriar(object messageString)
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
