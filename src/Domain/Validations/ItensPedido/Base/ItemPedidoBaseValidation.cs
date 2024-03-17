using Domain.Entities;
using FluentValidation;

namespace Domain.Validations.ItensPedido.Base
{
    public class ItemPedidoBaseValidation : ValidationBase<ItemPedido>
    {
        public ItemPedidoBaseValidation()
        {
            ValidarId();
            ValidarPedidoId();
            ValidarProdutoId();
        }

        public void ValidarPedidoId()
        {
            RuleFor(x => x.PedidoId).NotNull().NotEmpty().WithMessage("Informe um Id do pedido válido.");
        }

        public void ValidarProdutoId()
        {
            RuleFor(x => x.ProdutoId).NotNull().NotEmpty().WithMessage("Informe um produto.");
        }

        public void ValidarQuantidadeProduto()
        {
            RuleFor(x => x.ProdutoId).NotNull().NotEmpty().WithMessage("Informe um produto.");
        }
    }
}