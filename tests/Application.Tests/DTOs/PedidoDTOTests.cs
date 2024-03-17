using Application.DTOs;
using Domain.Enums;

namespace Application.Tests.DTOs
{
    public class PedidoDTOTests
    {
        [Fact]
        public void PedidoDTO_DeveRetornarVerdadeiro()
        {
            // Arrange
            Guid pedidoID = Guid.NewGuid();
            string numeroPedido = "102394jqsfjklasfdjkl";
            EStatusPedido eStatusPedido = EStatusPedido.PRONTO;

            // Act
            PedidoDTO pedidoDTO = new PedidoDTO
            {
                NumeroPedido = numeroPedido,
                EstatusPedido = eStatusPedido,
            };

            // Assert
            Assert.Equal(numeroPedido, pedidoDTO.NumeroPedido);
            Assert.Equal(eStatusPedido, pedidoDTO.EstatusPedido);
        }
    }
}
