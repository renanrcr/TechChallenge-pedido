using Domain.Validations.ItensPedido.Base;

namespace Domain.Validations.ItensPedido
{
    public class AtualizaItemPedidoValidation : ItemPedidoBaseValidation
    {
        public AtualizaItemPedidoValidation()
        {
            ValidarDataAtualizacao();
        }
    }
}