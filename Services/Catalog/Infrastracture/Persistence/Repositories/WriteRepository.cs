using Catalog.Application.Settings;
using FreeCourse.Shared.Entities.Commons;
using FreeCourse.Shared.Repositories;
using MongoDB.Driver;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class WriteRepository<TEntity>:IWriteRepository<TEntity> where TEntity:class,IEntity,new()
    {
        private readonly IDatabaseSettings _databaseSettings;
        public WriteRepository(IDatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }

        public async Task AddAsync(TEntity entity)
        {
            using var context = new MongoDBCatalogContext(_databaseSettings);
            var collection = context.GetCollection<TEntity>();
            await collection.InsertOneAsync(entity);
        }

        public async Task AddRangeAsync(List<TEntity> datas)
        {
            using var context = new MongoDBCatalogContext(_databaseSettings);
            var collection = context.GetCollection<TEntity>();
            await collection.InsertManyAsync(datas);
        }

        public bool Remove(TEntity entity)
        {
            using var context = new MongoDBCatalogContext(_databaseSettings);
            var collection = context.GetCollection<TEntity>();
            var deletedResult = collection.DeleteOne(x => x.Id == entity.Id);
            if (deletedResult.DeletedCount > 0)
                return true;
            return false;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            using var context = new MongoDBCatalogContext(_databaseSettings);
            var collection = context.GetCollection<TEntity>();
            var deletedResult =await collection.DeleteOneAsync(x => x.Id == id);
            if (deletedResult.DeletedCount > 0)
                return true;
            return false;
        }

        public bool Update(TEntity entity)
        {
            using var context = new MongoDBCatalogContext(_databaseSettings);
            var collection = context.GetCollection<TEntity>();
            var updatedResult = collection.ReplaceOne(x => x.Id == entity.Id, entity);
            if (updatedResult.ModifiedCount > 0)
                return true;
            return false;
        }
    }
}
