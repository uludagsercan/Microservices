using MediatR;

namespace Application.Services.Features.DiscountFeature.Queries.GetDiscountById
{
    public class GetDiscountByIdQueryRequest:IRequest<GetDiscountByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
