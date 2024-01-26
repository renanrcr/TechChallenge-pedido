using Application.DTOs;
using MediatR;

namespace Application.Commands.Pedidos
{
    public class DeletaPedidoCommand : IRequest<PedidoDTO>
    {
        public Guid Id { get; set; }
    }
}