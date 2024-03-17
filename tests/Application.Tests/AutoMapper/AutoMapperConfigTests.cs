using Application.AutoMapper;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Moq;

namespace Application.Tests.AutoMapper
{
    public class AutoMapperConfigTests
    {
        private readonly IMapper _mapper;

        public AutoMapperConfigTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperConfig>());
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task MapearPedidoParaPedidoDto_DeveRetornarVerdadeiro()
        {
            // Arrange
            Pedido pedido = await new Pedido().Cadastrar(Guid.NewGuid());

            // Act
            PedidoDTO pedidoDto = _mapper.Map<PedidoDTO>(pedido);

            // Assert
            Assert.Equal(pedido.NumeroPedido, pedidoDto.NumeroPedido);
        }

        [Fact]
        public async Task MapearItemPedidoParaItemPedidoDto_DeveRetornarVerdadeiro()
        {
            // Arrange
            var produto = new Mock<Produto>();
            ItemPedido itemPedido = await new ItemPedido().Cadastrar(Guid.NewGuid(), 0, produto.Object);

            // Act
            ItemPedidoDTO itemPedidoDto = _mapper.Map<ItemPedidoDTO>(itemPedido);

            // Assert
            Assert.Equal(itemPedido.PedidoId, itemPedidoDto.PedidoId);
        }
    }
}
