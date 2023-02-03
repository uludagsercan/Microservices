using FreeCourse.Shared.Entities.Commons;

namespace FreeCourse.Shared.Repositories
{
    public interface IWriteRepository<TEntity> where TEntity : class,IEntity,new()
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(List<TEntity> datas);
        bool Update(TEntity entity);
        bool Remove(TEntity entity);
        Task<bool> RemoveAsync(string id);

    }
}
