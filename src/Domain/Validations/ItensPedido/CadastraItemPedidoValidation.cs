using Domain.Adapters;
using Domain.Validations.ItensPedido.Base;

namespace Domain.Validations.ItensPedido
{
    public class CadastraItemPedidoValidation : ItemPedidoBaseValidation
    {
        public CadastraItemPedidoValidation(IProdutoRepository produtoRepository)
            : base(produtoRepository)
        {
            ValidarDataCadastro();
        }
    }
}