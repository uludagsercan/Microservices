using Application.Repositories.Discount;
using AutoMapper;
using Domain.Entities;
using FreeCourse.Shared.Dtos;
using MediatR;

namespace Application.Services.Features.DiscountFeature.Queries.GetAllDiscounts
{
    public class GetAllDiscountQueryHandler : IRequestHandler<GetAllDiscountQueryRequest, GetAllDiscountQueryResponse>
    {

        private readonly IDiscountReadRepository _discountReadRepository;

        public GetAllDiscountQueryHandler(IDiscountReadRepository discountReadRepository)
        {
            _discountReadRepository = discountReadRepository;
        }

        public async Task<GetAllDiscountQueryResponse> Handle(GetAllDiscountQueryRequest request, CancellationToken cancellationToken)
        {
            var sqlQuery = $"SELECT * FROM discount";
            var discounts = await _discountReadRepository.GetWhere(sqlQuery);
            return new()
            {
                Response = ResponseDto<IEnumerable<Discount>>.Success(discounts,200)
            };
        }
    }
}
