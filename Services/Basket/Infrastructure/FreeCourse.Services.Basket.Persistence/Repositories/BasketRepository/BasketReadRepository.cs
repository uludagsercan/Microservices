using FreeCourse.Services.Basket.Aplication.Services.Repositories;
using FreeCourse.Services.Basket.Aplication.Services.Repositories.BasketRepository;
using FreeCourse.Services.Basket.Persistence.Contexts;

namespace FreeCourse.Services.Basket.Persistence.Repositories.BasketRepository
{
    public class BasketReadRepository : ReadRepository<Domain.Entities.Basket>,IBasketReadRepository
    {
        private readonly RedisRepositoryContext _context;
        public BasketReadRepository(RedisRepositoryContext redisRepositoryContext) : base(redisRepositoryContext)
        {
            _context = redisRepositoryContext;
        }

       
    }
}
