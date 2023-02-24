using FreeCourse.Services.Order.Domain.Core;
using System.Linq.Expressions;

namespace FreeCourse.Services.Order.Application.Repositories
{
    public interface IReadRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> GetAll(bool tracking = true);
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method, bool tracking = true);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method, bool tracking = true);
        Task<TEntity> GetByIdAsync(int id, bool tracking = true);

    }
}
