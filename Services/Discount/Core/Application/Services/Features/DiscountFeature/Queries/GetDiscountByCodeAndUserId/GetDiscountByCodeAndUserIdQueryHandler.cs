using Application.Repositories.Discount;
using Domain.Entities;
using FreeCourse.Shared.Dtos;
using MediatR;

namespace Application.Services.Features.DiscountFeature.Queries.GetDiscountByCodeAndUserId
{
    public class GetDiscountByCodeAndUserIdQueryHandler : IRequestHandler<GetDiscountByCodeAndUserIdQueryRequest, GetDiscountByCodeAndUserIdQueryResponse>
    {
        private readonly IDiscountReadRepository _discountReadRepository;

        public GetDiscountByCodeAndUserIdQueryHandler(IDiscountReadRepository discountReadRepository)
        {
            _discountReadRepository = discountReadRepository;
        }

        public async Task<GetDiscountByCodeAndUserIdQueryResponse> Handle(GetDiscountByCodeAndUserIdQueryRequest request, CancellationToken cancellationToken)
        {

            var sqlQuery = $"SELECT * FROM discount where userid=@UserId AND code=@Code";
            var discount =await _discountReadRepository.GetSingleAsync(sqlQuery, new { UserId = request.UserId, Code = request.Code });

            return new()
            {
                Response = ResponseDto<Discount>.Success(discount, 200)
            };
        }
    }
}
