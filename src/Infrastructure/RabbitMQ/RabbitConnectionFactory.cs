using RabbitMQ.Client;

namespace Infrastructure.RabbitMQ
{
    public static class RabbitConnectionFactory
    {
        public static void CriarFilaPedidoCriar(this IModel model)
        {
            if(model == null) 
                throw new ArgumentNullException("model - create channel");

            IConnection connection = CriarConexao();

            model = connection.CreateModel();

            model.QueueDeclare(queue: "pedido_criar",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
        }

        private static IConnection CriarConexao() 
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

            return connectionfactory.CreateConnection();
        }
    }
}
