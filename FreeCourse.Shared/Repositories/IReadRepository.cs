using FreeCourse.Shared.Entities.Commons;
using System.Linq.Expressions;

namespace FreeCourse.Shared.Repositories
{
    public interface IReadRepository<TEntity> where TEntity : class,IEntity,new()
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetByIdAsync(string id);
    }
}
