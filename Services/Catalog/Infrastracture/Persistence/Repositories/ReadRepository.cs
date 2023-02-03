using Catalog.Application.Settings;
using FreeCourse.Shared.Entities.Commons;
using FreeCourse.Shared.Repositories;
using MongoDB.Driver;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly IDatabaseSettings _databaseSettings;
        public ReadRepository(IDatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }
        public IQueryable<TEntity> GetAll()
        {
            using var context = new MongoDBCatalogContext(_databaseSettings);
            var collection = context.GetCollection<TEntity>();
            return collection.AsQueryable();
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            using var context = new MongoDBCatalogContext(_databaseSettings);
            var builder = Builders<TEntity>.Filter.Where(x => x.Id == id);
            var collection =context.GetCollection<TEntity>();
            var filter = collection.Aggregate().Match(builder).SingleOrDefaultAsync();
            return await filter;
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> expression)
        {
            using var context = new MongoDBCatalogContext(_databaseSettings);
            var collection = context.GetCollection<TEntity>();
             return await collection.Aggregate().Match(expression).SingleOrDefaultAsync();
        }

        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> expression)
        {
            using var context = new MongoDBCatalogContext(_databaseSettings);
            var collection = context.GetCollection<TEntity>();
            return collection.AsQueryable().Where(expression);
        }
    }
}
