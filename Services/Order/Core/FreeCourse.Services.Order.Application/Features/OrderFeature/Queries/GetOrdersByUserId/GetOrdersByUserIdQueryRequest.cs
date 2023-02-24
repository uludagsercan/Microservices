using FreeCourse.Shared.Dtos;
using MediatR;

namespace FreeCourse.Services.Order.Application.Features.OrderFeature.Queries.GetOrdersByUserId
{
    public class GetOrdersByUserIdQueryRequest:IRequest<ResponseDto<List<GetOrdersByUserIdQueryResponse>>>
    {
        public string UserId { get; set; }
    }
}
