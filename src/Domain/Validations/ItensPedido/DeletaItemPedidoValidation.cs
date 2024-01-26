using Domain.Adapters;
using Domain.Validations.ItensPedido.Base;

namespace Domain.Validations.ItensPedido
{
    public class DeletaItemPedidoValidation : ItemPedidoBaseValidation
    {
        public DeletaItemPedidoValidation(IProdutoRepository produtoRepository)
            : base(produtoRepository)
        {
            ValidarDataExclusao();
        }
    }
}