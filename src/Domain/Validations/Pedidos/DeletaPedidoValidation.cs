using Domain.Validations.Pedidos.Base;

namespace Domain.Validations.Pedidos
{
    public class DeletaPedidoValidation : PedidoBaseValidation
    {
        public DeletaPedidoValidation()
        {
            ValidarDataExclusao();
        }
    }
}