using Domain.Adapters;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class TabelaPrecoRepository : Repository<TabelaPreco>, ITabelaPrecoRepository
    {
        public TabelaPrecoRepository(DataBaseContext dataBaseContext)
            : base(dataBaseContext)
        {
        }
    }
}