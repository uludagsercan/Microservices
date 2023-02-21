using MediatR;

namespace Application.Services.Features.DiscountFeature.Queries.GetDiscountByCodeAndUserId
{
    public class GetDiscountByCodeAndUserIdQueryRequest:IRequest<GetDiscountByCodeAndUserIdQueryResponse>
    {
        public string UserId { get; set; }
        public string Code { get; set; }
    }
}
