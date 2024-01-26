using Domain.Adapters;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DataBaseContext dataBaseContext)
            : base(dataBaseContext)
        {
        }
    }
}