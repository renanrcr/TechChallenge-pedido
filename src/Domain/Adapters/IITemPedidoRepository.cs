using Domain.Entities;

namespace Domain.Adapters
{
    public interface IItemPedidoRepository : IRepository<ItemPedido>
    {
        Task<IList<ItemPedido>> ObterItensDosPedidos();

        Task<IList<ItemPedido>> ObterItensDoPedidos(Guid pedidoId);

        Task<bool> InserirItemPedido(ItemPedido itemPedido);

        Task<bool> AtualizarQuantidadeItemPedido(ItemPedido itemPedido);
    }
}