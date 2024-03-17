using Domain.Adapters;
using Domain.Entities;
using Infrastructure.Tests.Adapters;
using Moq;

namespace Domain.Tests.Validations.Pedidos
{
    public class PedidoTests
    {
        private readonly IProdutoRepository _produtoRepository;

        public PedidoTests()
        {
            _produtoRepository = IProdutoRepositoryMock.GetMock();
        }

        [Fact]
        public async Task ItemPedido_DeveRetornarVerdadeiro_QuandoExistirItem()
        { 
            //Arrange
            Pedido? pedido = await new Pedido().Cadastrar(Guid.NewGuid());
            var produto = new Mock<Produto>();

            //Act
            ItemPedido? item = await new ItemPedido().Cadastrar(pedido.Id, 1, produto.Object);
            
            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(item);
                Assert.False(item.IsValid);
            });
        }

        [Fact]
        public async Task ItemPedido_DeveRetornarFalso_QuandoNaoExistirItem()
        { 
            //Arrange
            Pedido? pedido = await new Pedido().Cadastrar(Guid.NewGuid());
            var produto = new Mock<Produto>();

            //Act
            ItemPedido? item = await new ItemPedido().Cadastrar(pedido.Id, 1, produto.Object);
            
            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotNull(item);
                Assert.False(item?.IsValid);
            });
        }
    }
}