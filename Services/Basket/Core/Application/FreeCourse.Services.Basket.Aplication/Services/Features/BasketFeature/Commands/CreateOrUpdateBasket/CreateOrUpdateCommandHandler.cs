using FreeCourse.Services.Basket.Aplication.Services.Repositories.BasketRepository;
using MediatR;
using AutoMapper;
using FreeCourse.Shared.Services;

namespace FreeCourse.Services.Basket.Aplication.Services.Features.BasketFeature.Commands.CreateOrUpdateBasket
{
    public class CreateOrUpdateCommandHandler : IRequestHandler<CreateOrUpdateCommandRequest, CreateOrUpdateCommandResponse>
    {
        private readonly IBasketWriteRepository _basketWriteRepository;
        private readonly ISharedIdentityService _sharedIdentityService;
        private readonly IMapper _mapper;
        public CreateOrUpdateCommandHandler(IBasketWriteRepository basketWriteRepository, IMapper mapper, ISharedIdentityService sharedIdentityService)
        {
            _basketWriteRepository = basketWriteRepository;
            _mapper = mapper;
            _sharedIdentityService = sharedIdentityService;
        }

        public async Task<CreateOrUpdateCommandResponse> Handle(CreateOrUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var mappedBasket = _mapper.Map<Domain.Entities.Basket>(request);
            mappedBasket.UserId = _sharedIdentityService.GetUserId;
            var result = await _basketWriteRepository.SaveOrUpdateAsync(mappedBasket.UserId, mappedBasket);
            if (result)
                return new()
                {
                    Message = "Adding Successful",
                    StatusCode = 200
                };

            return new CreateOrUpdateCommandResponse()
            {
                Message = "Basket could not update or save",
                StatusCode = 500
            };
        }
    }
}
