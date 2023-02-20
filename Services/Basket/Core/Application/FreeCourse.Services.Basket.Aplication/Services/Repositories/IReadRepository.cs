using FreeCourse.Services.Basket.Domain.Entities.Common;
using System.Linq.Expressions;

namespace FreeCourse.Services.Basket.Aplication.Services.Repositories
{
    public interface IReadRepository<TEntity> where TEntity : BaseEntity,new()
    {
        Task<TEntity> GetEntityAsync(string userId);
       
    }
}
