using FreeCourse.Services.Order.Application.Repositories.OrderRepository;
using FreeCourse.Services.Order.Domain.OrderAggregate;
using FreeCourse.Services.Order.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FreeCourse.Services.Order.Persistence.Repositories.OrderRepository
{
    public class OrderReadRepository : ReadRepository<Domain.OrderAggregate.Order>, IOrderReadRepository
    {
        private readonly OrderRepositoryContext _context;
        public OrderReadRepository(OrderRepositoryContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<OrderItem> GetOrderItemsByCourseId(string courseId)
        {
            var orderItems = _context.OrderItems.Where(x => x.ProductId == courseId);
            return orderItems;
        }
    }
}
