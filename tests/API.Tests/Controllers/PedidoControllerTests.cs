using API.Controllers;
using Domain.Adapters;
using Infrastructure.Tests.Adapters;
using MediatR;
using Moq;

namespace API.Tests.Controllers
{
    public class PedidoControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<INotificador> _notification;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _notification = new Mock<INotificador>();
            _pedidoRepository = IPedidoRepositoryMock.GetMock();
        }

        [Fact]
        public void Pedido_DeveRetornarVerdadeiro_ListarPedidos()
        {
            //Arrange
            var controllerPedido = new PedidoController(_notification.Object, _mediatorMock.Object);

            //Act
            var result = controllerPedido.Get().Result;

            //Assert
            Assert.NotNull(result);
        }
    }
}
