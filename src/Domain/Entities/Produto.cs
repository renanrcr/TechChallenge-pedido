namespace Domain.Entities
{
    public class Produto : EntidadeBase<Guid>
    {
        public Guid CategoriaProdutoId { get; private set; }
        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public TabelaPreco TabelaPreco { get; private set; } = new();
        public ItemPedido? ItemPedido { get; private set; }

        public Produto NewInstance(string? nome, string? descricao)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Descricao = descricao;

            return this;
        }
    }
}