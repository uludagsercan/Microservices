using FreeCourse.Shared.Entities.Commons;
using FreeCourse.Shared.Repositories;
using MongoDB.Driver;

namespace Catalog.Application.Services.Repositories
{
    public interface IMongoDBReadRepository<TEntity>:IReadRepository<TEntity> where TEntity: class,IEntity,new()
    {
        IAggregateFluent<TEntity> GetAll(string collection, string collectionId, string relatedFieldName);
    }
}
