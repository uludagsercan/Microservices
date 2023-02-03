using Catalog.Application.Settings;
using MongoDB.Driver;

namespace Persistence.Contexts
{
    public class MongoDBCatalogContext:IDisposable
    { 
        private readonly IMongoDatabase _database;
        public MongoDBCatalogContext(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            _database = client.GetDatabase(databaseSettings.DatabaseName);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            return _database.GetCollection<TEntity>(typeof(TEntity).Name.Trim());
        }
        public IMongoDatabase GetDatabase()
        {
            return _database;
        }
    }
}
