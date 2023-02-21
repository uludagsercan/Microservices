using Domain.Entities;
using FreeCourse.Shared.Dtos;

namespace Application.Services.Features.DiscountFeature.Queries.GetAllDiscounts
{
    public class GetAllDiscountQueryResponse
    {
        public ResponseDto<IEnumerable<Discount>> Response { get; set; }
    }
}
