using Domain.Adapters;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Tests.Context;

namespace Infrastructure.Tests.Adapters
{
    public class IProdutoRepositoryMock
    {
        public static IProdutoRepository GetMock()
        {
            List<Produto> produtos = GenerateTestDataAsync();
            DataBaseContext dbContextMock = DbContextMock.GetMock<Produto, DataBaseContext>(produtos, x => x.Produtos);
            return new ProdutoRepository(dbContextMock);
        }

        private static List<Produto> GenerateTestDataAsync()
        {
            List<Produto> produtos = new();
            for (int index = 1; index <= 10; index++)
            {
                var produtoMock = new Produto();

                produtos.Add(produtoMock);
            }
            return produtos;
        }
    }
}
