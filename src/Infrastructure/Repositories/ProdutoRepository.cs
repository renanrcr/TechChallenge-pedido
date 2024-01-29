using Domain.Adapters;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DataBaseContext dataBaseContext)
            : base(dataBaseContext)
        {
        }
    }
}