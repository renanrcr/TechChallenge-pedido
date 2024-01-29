using Application.DTOs;
using MediatR;

namespace Application.Commands.Pedidos
{
    public class ListaPedidoCommand : IRequest<IList<PedidosDTO>>
    {
    }
}
