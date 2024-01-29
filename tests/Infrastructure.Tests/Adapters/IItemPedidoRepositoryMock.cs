using Domain.Adapters;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Tests.Context;

namespace Infrastructure.Tests.Adapters
{
    public class IItemPedidoRepositoryMock
    {
        private static IProdutoRepository? _produtoRepository;

        public IItemPedidoRepositoryMock()
        {
            _produtoRepository = IProdutoRepositoryMock.GetMock();
        }

        public static IItemPedidoRepository GetMock()
        {
            List<ItemPedido> itensPedido = GenerateTestDataAsync().Result;
            DataBaseContext dbContextMock = DbContextMock.GetMock<ItemPedido, DataBaseContext>(itensPedido, x => x.ItensPedido);
            return new ItemPedidoRepository(dbContextMock);
        }

        private static async Task<List<ItemPedido>> GenerateTestDataAsync()
        {
            List<ItemPedido> itensPedido = new();
            for (int index = 1; index <= 10; index++)
            {
                var itemPedido = await new ItemPedido().Cadastrar(_produtoRepository, Guid.NewGuid(), Guid.NewGuid(), index);

                itensPedido.Add(itemPedido);
            }
            return itensPedido;
        }
    }
}
