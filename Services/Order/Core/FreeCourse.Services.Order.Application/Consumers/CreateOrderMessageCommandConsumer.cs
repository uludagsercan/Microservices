using AutoMapper;
using FreeCourse.Services.Order.Application.Features.OrderFeature.Dtos;
using FreeCourse.Services.Order.Application.Repositories.OrderRepository;
using FreeCourse.Shared.Messages;
using MassTransit;

namespace FreeCourse.Services.Order.Application.Consumers
{
    public class CreateOrderMessageCommandConsumer : IConsumer<CreateOrderMessageCommand>
    {

        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IMapper _mapper;

        public CreateOrderMessageCommandConsumer(IOrderWriteRepository orderWriteRepository, IMapper mapper)
        {
            _orderWriteRepository = orderWriteRepository;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<CreateOrderMessageCommand> context)
        {
            var mappedOrder = _mapper.Map<CreateOrderDto>(context.Message);
            Domain.OrderAggregate.Order newOrder = new(new(mappedOrder.Address.Province, mappedOrder.Address.District, mappedOrder.Address.Street, mappedOrder.Address.ZipCode, mappedOrder.Address.Line)
           , mappedOrder.BuyerId);
            context.Message.OrderItems.ForEach(x =>
            {
                newOrder.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.PictureUrl);
            });
            var result = _orderWriteRepository.CreateAsync(newOrder);
            await _orderWriteRepository.SaveChangeAsync();

        }
    }
}
