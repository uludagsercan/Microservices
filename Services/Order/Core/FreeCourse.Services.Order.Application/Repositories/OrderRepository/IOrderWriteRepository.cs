using FreeCourse.Services.Order.Domain.Core;

namespace FreeCourse.Services.Order.Application.Repositories.OrderRepository
{
    public interface IOrderWriteRepository:IWriteRepository<Domain.OrderAggregate.Order> 
    {
    }
}
