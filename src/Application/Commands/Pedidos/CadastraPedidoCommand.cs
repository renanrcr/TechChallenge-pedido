using Application.DTOs;
using MediatR;

namespace Application.Commands.Pedidos
{
    public class CadastraPedidoCommand : IRequest<PedidoDTO>
    {
        public Guid ClienteId { get; set; }
    }
}