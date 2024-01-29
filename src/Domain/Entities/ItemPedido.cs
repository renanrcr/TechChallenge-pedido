using Domain.Adapters;
using Domain.Validations.ItensPedido;

namespace Domain.Entities
{
    public class ItemPedido : EntidadeBase<Guid>
    {
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public decimal Quantidade { get; private set; }
        public Produto Produto { get; private set; } = new Produto();
        public Pedido? Pedido { get; private set; }

        public async Task<ItemPedido> Cadastrar(IProdutoRepository produtoRepository, Guid pedidoId, Guid produtoId, decimal quantidade)
        {
            Id = Guid.NewGuid();
            PedidoId = pedidoId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
            DataCadastro = DateTime.Now;

            await Validate(this, new CadastraItemPedidoValidation(produtoRepository));

            return this;
        }

        public async Task<ItemPedido> Atualizar(IProdutoRepository produtoRepository, Guid id, decimal quantidade)
        {
            Id = id;
            Quantidade = quantidade;
            DataAtualizacao = DateTime.Now;

            await Validate(this, new AtualizaItemPedidoValidation(produtoRepository));

            return this;
        }

        public async Task<ItemPedido> Deletar(IProdutoRepository produtoRepository, Guid id)
        {
            Id = id;
            DataExclusao = DateTime.Now;
            await Validate(this, new DeletaItemPedidoValidation(produtoRepository));

            return this;
        }
    }
}