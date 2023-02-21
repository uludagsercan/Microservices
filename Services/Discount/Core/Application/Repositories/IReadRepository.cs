using FreeCourse.Shared.Entities.Commons;

namespace Application.Repositories
{
    public interface IReadRepository<TEntity> where TEntity : class,IEntity, new()
    {
        Task<IEnumerable<TEntity>> GetWhere(string query,object param = null);
        Task<TEntity> GetSingleAsync(string query,object param);
    }
}
