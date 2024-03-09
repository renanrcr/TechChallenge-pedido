using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Infrastructure.Tests.Context
{
    public class DbContextMock
    {
        public static DataBaseContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase(databaseName: "DataBaseTests")
                .Options;

            var dbContext = new DataBaseContext(options);

            return dbContext;
        }

        public static IMongoDatabase CreateMongoDb()
        {
            var coonectionStringMongoDB = "mongodb://mongodb:27017";
            var mongoClient = new MongoClient(coonectionStringMongoDB);
            var databaseMongoDB = mongoClient.GetDatabase("Pedido");

            return databaseMongoDB;
        }
    }
}
