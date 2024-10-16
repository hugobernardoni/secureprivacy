using Microsoft.Extensions.Configuration;
using Model.Models;
using MongoDB.Driver;

namespace DAO
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var mongoConnectionString = configuration["MongoDb:ConnectionString"];
            var databaseName = configuration["MongoDb:DatabaseName"];

            var client = new MongoClient(mongoConnectionString);
            _database = client.GetDatabase(databaseName);

        }

        public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");

        public void ConfigureIndexes()
        {
            var indexKeysDefinition = Builders<Product>.IndexKeys
                .Ascending(p => p.Name)
                .Descending(p => p.Price);

            var indexModel = new CreateIndexModel<Product>(indexKeysDefinition);
            Products.Indexes.CreateOne(indexModel);
        }
    }
}
