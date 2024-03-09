using Domain.Entities;

namespace Domain.Adapters
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<IList<Pedido>> ObterPedido();

        Task<bool> InserirPedido(Pedido pedido);

        Task<bool> AtualizarStatusDoPedido(Pedido pedido);

        Task<bool> DeletarPedido(Guid idPedido);
    }
}