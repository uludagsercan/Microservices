using Application.Repositories.Discount;
using Domain.Entities;
using FreeCourse.Shared.Dtos;
using MediatR;

namespace Application.Services.Features.DiscountFeature.Queries.GetDiscountById
{
    public class GetDiscountByIdQueryHandler : IRequestHandler<GetDiscountByIdQueryRequest, GetDiscountByIdQueryResponse>
    {
        private readonly IDiscountReadRepository _discountReadRepository;

        public GetDiscountByIdQueryHandler(IDiscountReadRepository discountReadRepository)
        {
            _discountReadRepository = discountReadRepository;
        }

        public async Task<GetDiscountByIdQueryResponse> Handle(GetDiscountByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var sqlQuery = $"SELECT * FROM discount where id=@Id";
            var discount =await _discountReadRepository.GetSingleAsync(sqlQuery, new { Id = request.Id });
            return new()
            {
                Response = ResponseDto<Discount>.Success(discount, 200)
            };
        }
    }
}
