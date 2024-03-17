using Domain.Adapters;
using Infrastructure.RabbitMQ;
using Infrastructure.Repositories;
using Moq;
using RabbitMQ.Client;

namespace Infrastructure.Tests.Adapters
{
    public class IMessageServiceMock
    {
        public class ConnectionFactoryCreatorMock : RabbitMQ.IConnectionFactory
        {
            public ConnectionFactory Get()
            {
                return new ConnectionFactory
                {
                    HostName = "localhost",
                    Port = 5672,
                    UserName = "guest",
                    Password = "guest",
                };
            }
        }

        public static IMessageServiceRepository GetMock()
        {
            RabbitMQ.IConnectionFactory connectionFactory = new ConnectionFactoryCreatorMock();
            var rabbitPublish  = new Mock<RabbitPublish>();

            return new MessageServiceRepository(connectionFactory, rabbitPublish.Object);
        }
    }
}
