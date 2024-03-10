using Domain.Adapters;
using Infrastructure.Repositories;
using Moq;
using RabbitMQ.Client;

namespace Infrastructure.Tests.Adapters
{
    public class IMessageServiceMock
    {
        public static IMessageService GetMock()
        {
            var channelMock = new Mock<IModel>();
            channelMock
                .Setup(m => m.BasicPublish(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<IBasicProperties>(), It.IsAny<byte[]>()))
                .Callback<string, bool, object, IBasicConsumer>((queue, noAck, props, consumer) => consumer.HandleBasicDeliver("", 1, false, "Print", "pedido", null, new byte[0]));

            return new MessageServiceRepository(channelMock.Object);
        }
    }
}
