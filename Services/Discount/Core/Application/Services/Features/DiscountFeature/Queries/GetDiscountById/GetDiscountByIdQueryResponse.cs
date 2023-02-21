using Domain.Entities;
using FreeCourse.Shared.Dtos;

namespace Application.Services.Features.DiscountFeature.Queries.GetDiscountById
{
    public class GetDiscountByIdQueryResponse
    {
        public ResponseDto<Discount> Response { get; set; }
    }
}
