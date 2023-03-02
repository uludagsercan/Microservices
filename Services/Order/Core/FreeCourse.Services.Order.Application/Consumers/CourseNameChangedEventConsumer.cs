using FreeCourse.Services.Order.Application.Repositories.OrderRepository;
using FreeCourse.Shared.Messages;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace FreeCourse.Services.Order.Application.Consumers
{
    public class CourseNameChangedEventConsumer : IConsumer<CreateNameChangedEvent>
    {
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;

        public CourseNameChangedEventConsumer(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        public async Task Consume(ConsumeContext<CreateNameChangedEvent> context)
        {
           var orderItems =await _orderReadRepository.GetOrderItemsByCourseId(context.Message.CourseId).ToListAsync();

            orderItems.ForEach(orderItem =>
            {
                orderItem.UpdateOrderItem(context.Message.UpdatedName, orderItem.PictureUrl, orderItem.Price);
            });
            await _orderWriteRepository.SaveChangeAsync();
        }
    }
}
