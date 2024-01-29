using Application.AutoMapper;
using Application.Commands.Pedidos;
using Application.Services.Handlers;
using AutoMapper;
using Domain.Adapters;
using Domain.Notificacoes;
using Infrastructure.Tests.Adapters;

namespace Application.Tests.Services.Handlers
{
    public class PedidoHandlerTests
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IItemPedidoRepository _itemPedidoRepository;
        private readonly INotificador _notificador;
        private readonly IMapper _mapper;

        public PedidoHandlerTests()
        {
            _pedidoRepository = IPedidoRepositoryMock.GetMock();
            _itemPedidoRepository = IItemPedidoRepositoryMock.GetMock();
            _notificador = new Notificador(); 

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperConfig>());
            _mapper = config.CreateMapper();
        }

        [Fact]
        public void Pedido_DeveRetornarVerdadeiro_QuandoCadastrarNovoPedido()
        {
            //Arrange
            PedidoHandler pedidoHandler = new PedidoHandler(_notificador, _pedidoRepository, _itemPedidoRepository, _mapper);

            var cadastraPedidoCommand = new CadastraPedidoCommand()
            {
               IdentificacaoClienteId = Guid.NewGuid(),
            };

            //Act
            var result = pedidoHandler.Handle(cadastraPedidoCommand, default).Result;

            //Assert
            Assert.NotNull(result);
            Assert.True(string.IsNullOrEmpty(result.NumeroPedido));
        }
    }
}
