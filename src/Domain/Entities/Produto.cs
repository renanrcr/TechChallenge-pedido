namespace Domain.Entities
{
    public class Produto : EntidadeBase<Guid>
    {
        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public TabelaPreco TabelaPreco { get; private set; } = new();

        public Produto NewInstance(string? nome, string? descricao, decimal preco)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Descricao = descricao;
            TabelaPreco = new TabelaPreco().NewInstance(Id, preco);

            return this;
        }
    }
}