using Domain.Adapters;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class IdentificacaoPedidoRepository : Repository<IdentificacaoPedido>, IIdentificacaoPedidoRepository
    {
        public IdentificacaoPedidoRepository(DataBaseContext dataBaseContext)
            : base(dataBaseContext)
        {
        }
    }
}