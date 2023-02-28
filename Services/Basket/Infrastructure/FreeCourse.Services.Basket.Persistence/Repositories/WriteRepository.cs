using FreeCourse.Services.Basket.Aplication.Services.Repositories;
using FreeCourse.Services.Basket.Domain.Entities.Common;
using FreeCourse.Services.Basket.Persistence.Contexts;
using System.Text.Json;

namespace FreeCourse.Services.Basket.Persistence.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly RedisRepositoryContext _redisRepositoryContext;

        public WriteRepository(RedisRepositoryContext redisRepositoryContext)
        {
            _redisRepositoryContext = redisRepositoryContext;
        }

        public async Task<bool> DeleteAsync(string key)
        {
            var status = await _redisRepositoryContext.GetDatabase().KeyDeleteAsync(key);
            return status;
        }

        public async Task<bool> SaveOrUpdateAsync(string key,TEntity entity)
        {
            var status = await _redisRepositoryContext.GetDatabase().StringSetAsync(key, JsonSerializer.Serialize(entity));
            return status;
        }
    }
}
