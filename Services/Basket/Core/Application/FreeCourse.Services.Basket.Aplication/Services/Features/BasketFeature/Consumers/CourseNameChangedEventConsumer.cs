using FreeCourse.Services.Basket.Aplication.Services.Repositories.BasketRepository;
using FreeCourse.Shared.Messages;
using FreeCourse.Shared.Services;
using MassTransit;
using Microsoft.AspNetCore.Http;

namespace FreeCourse.Services.Basket.Aplication.Services.Features.BasketFeature.Consumers
{
    public class CourseNameChangedEventConsumer : IConsumer<CreateNameChangedEvent>
    {
        private readonly IBasketReadRepository _basketReadRepository;
        private readonly IBasketWriteRepository _basketWriteRepository;

        public CourseNameChangedEventConsumer(IBasketReadRepository basketReadRepository, IBasketWriteRepository basketWriteRepository)
        {
            _basketReadRepository = basketReadRepository;
            _basketWriteRepository = basketWriteRepository;
        }

        public async Task Consume(ConsumeContext<CreateNameChangedEvent> context)
        {
            var userId = context.Headers.Get<string>("userId");
            var basket = await _basketReadRepository.GetEntityAsync(userId);
            basket.BasketItems.ForEach(x =>
            {
                if (x.CourseId == context.Message.CourseId)
                    x.CourseName = context.Message.UpdatedName;
            });
            await _basketWriteRepository.SaveOrUpdateAsync(userId, basket);
        }
        //public Task Consume(ConsumeContext<CreateNameChangedEvent> context)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
