using Domain.Adapters;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class ItemPedidoRepository : Repository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(DataBaseContext dataBaseContext)
            : base(dataBaseContext)
        {
        }
    }
}