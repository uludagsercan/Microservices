using AutoMapper;
using FreeCourse.Services.Basket.Aplication.Services.Repositories.BasketRepository;
using MediatR;
using FreeCourse.Services.Basket.Aplication.Services.Features.BasketFeature.Queries.GetBasket;
using FreeCourse.Shared.Services;

namespace FreeCourse.Services.Basket.Aplication.Services.Features.BasketFeature.Queries.GetBasket
{
    public class GetBasketQueryHandler : IRequestHandler<GetBasketQueryRequest, GetBasketQueryResponse>
    {
        private readonly IBasketReadRepository _basketReadRepository;
        private readonly IMapper _mapper;
        private readonly ISharedIdentityService _sharedIdentityService;

        public GetBasketQueryHandler(IBasketReadRepository basketReadRepository, IMapper mapper, ISharedIdentityService sharedIdentityService)
        {
            _basketReadRepository = basketReadRepository;
            _mapper = mapper;
            _sharedIdentityService = sharedIdentityService;
        }

        public async Task<GetBasketQueryResponse> Handle(GetBasketQueryRequest request, CancellationToken cancellationToken)
        {
            var basketResult = await _basketReadRepository.GetEntityAsync(_sharedIdentityService.GetUserId);
            if (basketResult == null)
                return new ErrorBasketResult()
                {
                    Message = "Basket Not Found",
                    StatusCode = 404
                };
            return new SuccessBasketResult()
            {

                Basket = basketResult,
                StatusCode = 200
            };
        }
    }
}
