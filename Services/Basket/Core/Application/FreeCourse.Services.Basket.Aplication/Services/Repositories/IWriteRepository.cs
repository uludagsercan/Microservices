using FreeCourse.Services.Basket.Domain.Entities.Common;

namespace FreeCourse.Services.Basket.Aplication.Services.Repositories
{
    public interface IWriteRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<bool> SaveOrUpdateAsync(string key,TEntity entity);
        Task<bool> DeleteAsync(string key);
    }
}
