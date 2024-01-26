using Application.DTOs;
using MediatR;

namespace Application.Commands.ItensPedido
{
    public class CadastraItemPedidoCommand : IRequest<ItemPedidoDTO>
    {
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
        public decimal Quantidade { get; set; }
    }
}
