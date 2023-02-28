using FreeCourse.Services.Basket.Aplication.Services.Repositories;
using FreeCourse.Services.Basket.Aplication.Services.Repositories.BasketRepository;
using FreeCourse.Services.Basket.Persistence.Contexts;

namespace FreeCourse.Services.Basket.Persistence.Repositories.BasketRepository
{
    public class BasketWriteRepository : WriteRepository<Domain.Entities.Basket>, IBasketWriteRepository
    {
        public BasketWriteRepository(RedisRepositoryContext redisRepositoryContext) : base(redisRepositoryContext)
        {
        }
    }
}
