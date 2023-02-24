using FreeCourse.Services.Order.Application.Features.OrderFeature.Dtos;
using FreeCourse.Shared.Dtos;
using MediatR;

namespace FreeCourse.Services.Order.Application.Features.OrderFeature.Commands.CreateOrder
{
    public class CreateOrderCommandRequest:IRequest<ResponseDto<CreateOrderCommandResponse>>
    {
        public string BuyerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public AddressDto Address { get; set; }
    }
}
