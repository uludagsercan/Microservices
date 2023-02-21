using FreeCourse.Shared.Entities.Commons;

namespace Application.Repositories
{
    public interface IWriteRepository<TEntity> where TEntity : class, IEntity, new()
    {
        Task<bool> SaveAsync(string query,object param);
        Task<bool> DeleteAsync(string query,object param);
    }
}
