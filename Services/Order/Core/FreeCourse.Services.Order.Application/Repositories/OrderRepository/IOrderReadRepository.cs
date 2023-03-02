using FreeCourse.Services.Order.Domain.Core;
using FreeCourse.Services.Order.Domain.OrderAggregate;

namespace FreeCourse.Services.Order.Application.Repositories.OrderRepository
{
    public interface IOrderReadRepository: IReadRepository<Domain.OrderAggregate.Order>
    {
        IQueryable<OrderItem> GetOrderItemsByCourseId(string courseId);
    }
}
