using FreeCourse.Services.Order.Domain.Core;

namespace FreeCourse.Services.Order.Application.Repositories
{
    public interface IWriteRepository<TEntity> where TEntity : Entity
    {
        Task<bool> CreateAsync(TEntity entity);
        bool Update(TEntity entity);
        Task<bool> Remove(int id);
        Task SaveChangeAsync();

    }
}
