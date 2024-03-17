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
        private readonly PedidoHandler _pedidoHandler;
        private readonly IMessageServiceRepository _messageService;

        public PedidoHandlerTests()
        {
            _pedidoRepository = IPedidoRepositoryMock.GetMock();
            _itemPedidoRepository = IItemPedidoRepositoryMock.GetMock();
            _messageService = IMessageServiceMock.GetMock();
            _notificador = new Notificador();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperConfig>());
            _mapper = config.CreateMapper();

            _pedidoHandler = new PedidoHandler(_notificador, _pedidoRepository, _itemPedidoRepository, _mapper, _messageService);
        }

        [Fact]
        public void Pedido_DeveRetornarVerdadeiro_QuandoCadastrarNovo()
        {
            //Arrange

            var command = new CadastraPedidoCommand()
            {
               ClienteId = Guid.NewGuid(),
            };

            //Act
            var result = _pedidoHandler.Handle(command, default);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Pedido_DeveRetornarVerdadeiro_QuandoAtualizar()
        {
            //Arrange
            var dado = _pedidoHandler.Handle(new CadastraPedidoCommand() {  ClienteId = Guid.NewGuid(), }, default).Result;

            var command = new AtualizaPedidoCommand()
            {
                NumeroPedido = dado.NumeroPedido,
            };

            //Act
            var result = _pedidoHandler.Handle(command, default);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Pedido_DeveRetornarVerdadeiro_QuandoRemover()
        {
            //Arrange
            var dado = _pedidoRepository.ObterTodos().Result.FirstOrDefault() ?? new();

            var command = new DeletaPedidoCommand()
            {
                Id = dado.Id,
            };

            //Act
            var result = _pedidoHandler.Handle(command, default);

            //Assert
            Assert.NotNull(result);
        }
    }
}
