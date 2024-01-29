using Domain.Adapters;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Tests.Context;

namespace Infrastructure.Tests.Adapters
{
    public class IIdentificacaoPedidoRepositoryMock
    {
        public static IIdentificacaoPedidoRepository GetMock()
        {
            List<IdentificacaoPedido> identificacaoPedido = GenerateTestDataAsync();
            DataBaseContext dbContextMock = DbContextMock.GetMock<IdentificacaoPedido, DataBaseContext>(identificacaoPedido, x => x.IdentificacaoPedidos);
            return new IdentificacaoPedidoRepository(dbContextMock);
        }

        private static List<IdentificacaoPedido> GenerateTestDataAsync()
        {
            List<IdentificacaoPedido> identificacoesPedido = new();
            for (int index = 1; index <= 10; index++)
            {
                var pedidoMock = new IdentificacaoPedido().NewInstance(Guid.NewGuid().ToString(), (int)ETipoIdentificacaoPedido.NAO_IDENTIFICADO);

                identificacoesPedido.Add(pedidoMock);
            }
            return identificacoesPedido;
        }
    }
}
