using Application.DTOs;
using MediatR;

namespace Application.Commands.ItensPedido
{
    public class DeletaItemPedidoCommand : IRequest<ItemPedidoDTO>
    {
        public Guid Id { get; set; }
    }
}