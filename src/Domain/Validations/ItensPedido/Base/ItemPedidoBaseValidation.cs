using Domain.Adapters;
using Domain.Entities;
using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validations.ItensPedido.Base
{
    public class ItemPedidoBaseValidation : ValidationBase<ItemPedido>
    {
        private IProdutoRepository _produtoRepository;

        public ItemPedidoBaseValidation(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;

            ValidarId();
            ValidarPedidoId();
            ValidarProdutoId();
            ValidarExisteProdutoCadastrado();
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

        public void ValidarExisteProdutoCadastrado()
        {
            RuleFor(s => s.Id).NotEmpty()
                .MustAsync(ExisteProduto).WithMessage(MensagemRetorno.ProdutoNaoCadastrado);
        }

        private async Task<bool> ExisteProduto(Guid id, CancellationToken token)
        {
            return await _produtoRepository.Existe(x => x.Id == id);
        }
    }
}