using FreeCourse.Services.Basket.Aplication.Services.Repositories;
using FreeCourse.Services.Basket.Domain.Entities.Common;
using FreeCourse.Services.Basket.Persistence.Contexts;
using System.Text.Json;

namespace FreeCourse.Services.Basket.Persistence.Repositories
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity: BaseEntity, new()
    {
        private readonly RedisRepositoryContext _redisRepositoryContext;

        public ReadRepository(RedisRepositoryContext redisRepositoryContext)
        {
            _redisRepositoryContext = redisRepositoryContext;
        }

       public async Task<TEntity> GetEntityAsync(string id)
        {
         
            var existBasket = await _redisRepositoryContext.GetDatabase().StringGetAsync(id);
            if (!string.IsNullOrEmpty(existBasket))
                return JsonSerializer.Deserialize<TEntity>(existBasket);
            return null;
        }
    }
}
