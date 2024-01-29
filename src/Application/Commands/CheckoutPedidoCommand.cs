using Application.DTOs;
using Domain.Enums;
using MediatR;

namespace Application.Commands
{
    public class CheckoutPedidoCommand : IRequest<CheckoutPedidoDTO>
    {
        public int TipodIdentificacaoCliente { get; set; } = (int)ETipoIdentificacaoPedido.NAO_IDENTIFICADO;

        public string? IdentificacaoCliente { get; set; }

        public IList<ItemPedidoDTO>? ItensPedido { get; set; }
    }
}