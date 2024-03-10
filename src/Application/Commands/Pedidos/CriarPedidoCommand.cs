using MediatR;

namespace Application.Commands.Pedidos
{
    public class CriarPedidoCommand : IRequest<bool>
    {
        public string? NumeroPedido { get; set; }
    }
}