using FreeCourse.Shared.Entities.Commons;

namespace Application.Repositories
{
    public interface IReadRepository<TEntity> where TEntity : class,IEntity, new()
    {
        Task<IEnumerable<TEntity>> GetAllAsync(string query);
        Task<TEntity> GetWhere(string query);
    }
}
