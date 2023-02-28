using AutoMapper;
using FreeCourse.Services.Order.Application.Features.OrderFeature.Commands.CreateOrder;
using FreeCourse.Services.Order.Application.Features.OrderFeature.Dtos;
using FreeCourse.Services.Order.Application.Features.OrderFeature.Queries.GetOrdersByUserId;
using FreeCourse.Shared.Messages;

namespace FreeCourse.Services.Order.Application.Features.OrderFeature.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.OrderAggregate.Address,AddressDto>().ReverseMap();
            CreateMap<Domain.OrderAggregate.OrderItem,OrderItemDto>().ReverseMap();
            CreateMap<Domain.OrderAggregate.Order, GetOrdersByUserIdQueryResponse>().ReverseMap();
            
            CreateMap<CreateOrderDto,CreateOrderCommandRequest>().ReverseMap();
            CreateMap<CreateOrderDto, CreateOrderMessageCommand>().ReverseMap();
            CreateMap<FreeCourse.Shared.Messages.Address, AddressDto>().ReverseMap();
        }

    }
}
