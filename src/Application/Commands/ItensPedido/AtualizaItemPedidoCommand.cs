using Application.DTOs;
using MediatR;

namespace Application.Commands.ItensPedido
{
    public class AtualizaItemPedidoCommand : IRequest<ItemPedidoDTO>
    {
        public Guid Id { get; set; }
        public decimal Quantidade { get; set; }
    }
}