using Domain.Validations.ItensPedido.Base;

namespace Domain.Validations.ItensPedido
{
    public class DeletaItemPedidoValidation : ItemPedidoBaseValidation
    {
        public DeletaItemPedidoValidation()
        {
            ValidarDataExclusao();
        }
    }
}