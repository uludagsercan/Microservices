using AutoMapper;
using FreeCourse.Services.Order.Application.Repositories.OrderRepository;
using FreeCourse.Shared.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FreeCourse.Services.Order.Application.Features.OrderFeature.Queries.GetOrdersByUserId
{
    public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQueryRequest, ResponseDto<List<GetOrdersByUserIdQueryResponse>>>
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IMapper _mapper;

        public GetOrdersByUserIdQueryHandler(IOrderReadRepository orderReadRepository, IMapper mapper)
        {
            _orderReadRepository = orderReadRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<GetOrdersByUserIdQueryResponse>>> Handle(GetOrdersByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            var orders = await _orderReadRepository.GetWhere(x => x.BuyerId == request.UserId).Include(x => x.OrderItems).ToListAsync();
            if (!orders.Any())
            {
                return ResponseDto<List<GetOrdersByUserIdQueryResponse>>.Success(new(), 200);
            }
            var ordersDto = _mapper.Map<List<GetOrdersByUserIdQueryResponse>>(orders);
            return ResponseDto<List<GetOrdersByUserIdQueryResponse>>.Success(ordersDto, 200);
        }
    }
}
