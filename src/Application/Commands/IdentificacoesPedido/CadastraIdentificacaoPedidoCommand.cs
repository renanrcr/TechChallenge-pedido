using Application.DTOs;
using Domain.Enums;
using MediatR;

namespace Application.Commands.IdentificacoesPedido
{
    public class CadastraIdentificacaoPedidoCommand : IRequest<IdentificacaoPedidoDTO>
    {
        public string? Valor { get; set; }
        public int TipodIdentificacaoPedido { get; set; } = (int)ETipoIdentificacaoPedido.NAO_IDENTIFICADO;
    }
}