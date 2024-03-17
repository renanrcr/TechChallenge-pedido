using Domain.Validations.ItensPedido;

namespace Domain.Entities
{
    public class ItemPedido : EntidadeBase<Guid>
    {
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public decimal Quantidade { get; private set; }
        public Produto Produto { get; private set; } = new();

        public async Task<ItemPedido> Cadastrar(Guid pedidoId, decimal quantidade, Produto produto)
        {
            Id = Guid.NewGuid();
            PedidoId = pedidoId;
            ProdutoId = produto.Id;
            Quantidade = quantidade;
            Produto = produto;
            DataCadastro = DateTime.Now;

            await Validate(this, new CadastraItemPedidoValidation());

            return this;
        }

        public async Task<ItemPedido> Atualizar(Guid id, decimal quantidade)
        {
            Id = id;
            Quantidade = quantidade;
            DataAtualizacao = DateTime.Now;

            await Validate(this, new AtualizaItemPedidoValidation());

            return this;
        }

        public async Task<ItemPedido> Deletar(Guid id)
        {
            Id = id;
            DataExclusao = DateTime.Now;
            await Validate(this, new DeletaItemPedidoValidation());

            return this;
        }
    }
}