using Domain.Validations.Pedidos.Base;

namespace Domain.Validations.Pedidos
{
    public class AtualizaPedidoValidation : PedidoBaseValidation
    {
        public AtualizaPedidoValidation()
        {
            ValidarDataAtualizacao();
        }
    }
}