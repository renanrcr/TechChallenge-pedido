using Domain.Adapters;
using Domain.Validations.ItensPedido.Base;

namespace Domain.Validations.ItensPedido
{
    public class AtualizaItemPedidoValidation : ItemPedidoBaseValidation
    {
        public AtualizaItemPedidoValidation(IProdutoRepository produtoRepository)
            : base(produtoRepository)
        {
            ValidarDataAtualizacao();
        }
    }
}