using Domain.Validations.ItensPedido.Base;

namespace Domain.Validations.ItensPedido
{
    public class CadastraItemPedidoValidation : ItemPedidoBaseValidation
    {
        public CadastraItemPedidoValidation()
        {
            ValidarDataCadastro();
        }
    }
}