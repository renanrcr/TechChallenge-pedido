using Domain.Enums;

namespace Application.DTOs
{
    public class PedidoDTO
    {
        public string? NumeroPedido { get; set; }
        public EStatusPedido EstatusPedido { get; set; }
    }
}