using Application.DTOs;
using MediatR;

namespace Application.Commands.Pedidos
{
    public class AtualizaPedidoCommand : IRequest<PedidoDTO>
    {
        public string? NumeroPedido { get; set; }
        public Guid IdentificacaoPedidoId { get; set; }
    }
}