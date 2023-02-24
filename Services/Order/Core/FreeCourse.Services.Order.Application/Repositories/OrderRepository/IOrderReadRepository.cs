using FreeCourse.Services.Order.Domain.Core;

namespace FreeCourse.Services.Order.Application.Repositories.OrderRepository
{
    public interface IOrderReadRepository: IReadRepository<Domain.OrderAggregate.Order>
    {
    }
}
