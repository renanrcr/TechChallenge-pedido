using Domain.Adapters;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class CategoriaProdutoRepository : Repository<CategoriaProduto>, ICategoriaProdutoRepository
    {
        public CategoriaProdutoRepository(DataBaseContext dataBaseContext)
            : base(dataBaseContext)
        {
        }
    }
}