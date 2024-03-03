using Domain.Adapters;
using Infrastructure.Repositories;
using Infrastructure.Tests.Context;

namespace Infrastructure.Tests.Adapters
{
    public class IItemPedidoRepositoryMock
    {
        public static IItemPedidoRepository GetMock()
        {
            var dbContext = DbContextMock.CreateDbContext();
            var mongoDb = DbContextMock.CreateMongoDb();

            return new ItemPedidoRepository(dbContext, mongoDb);
        }
    }
}
