namespace Domain.Entities
{
    public class TabelaPreco : EntidadeBase<Guid>
    {
        public Guid ProdutoId { get; set; }
        public decimal Preco { get; private set; }

        public TabelaPreco NewInstance(Guid produtoId, decimal preco)
        {
            Id = Guid.NewGuid();
            ProdutoId = produtoId;
            Preco = preco;

            return this;
        }
    }
}