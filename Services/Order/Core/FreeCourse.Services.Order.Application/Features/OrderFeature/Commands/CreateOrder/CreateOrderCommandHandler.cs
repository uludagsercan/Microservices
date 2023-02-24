using AutoMapper;
using FreeCourse.Services.Order.Application.Features.OrderFeature.Dtos;
using FreeCourse.Services.Order.Application.Repositories.OrderRepository;
using FreeCourse.Services.Order.Domain.OrderAggregate;
using FreeCourse.Shared.Dtos;
using MediatR;

namespace FreeCourse.Services.Order.Application.Features.OrderFeature.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, ResponseDto<CreateOrderCommandResponse>>
    {

        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderWriteRepository orderWriteRepository, IMapper mapper)
        {
            _orderWriteRepository = orderWriteRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<CreateOrderCommandResponse>> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {

            var mappedOrder = _mapper.Map<CreateOrderDto>(request);
            Domain.OrderAggregate.Order newOrder = new(new(mappedOrder.Address.Province, mappedOrder.Address.District, mappedOrder.Address.Street, mappedOrder.Address.ZipCode, mappedOrder.Address.Line)
           , mappedOrder.BuyerId);
            request.OrderItems.ForEach(x =>
            {
                newOrder.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.PictureUrl);
            });
            var result = _orderWriteRepository.CreateAsync(newOrder);
            await _orderWriteRepository.SaveChangeAsync();
            return ResponseDto<CreateOrderCommandResponse>.Success(new()
            {
                OrderId = newOrder.Id,
            }, 200);
        }
    }
}
