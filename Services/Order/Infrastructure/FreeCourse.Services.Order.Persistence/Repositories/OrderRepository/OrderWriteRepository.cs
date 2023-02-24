using FreeCourse.Services.Order.Application.Repositories.OrderRepository;
using FreeCourse.Services.Order.Persistence.Contexts;

namespace FreeCourse.Services.Order.Persistence.Repositories.OrderRepository
{
    public class OrderWriteRepository : WriteRepository<Domain.OrderAggregate.Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(OrderRepositoryContext context) : base(context)
        {
        }
    }
}
