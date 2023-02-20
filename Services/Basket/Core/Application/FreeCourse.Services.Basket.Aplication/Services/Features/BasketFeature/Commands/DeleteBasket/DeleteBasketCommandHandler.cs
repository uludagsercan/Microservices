using FreeCourse.Services.Basket.Aplication.Services.Repositories.BasketRepository;
using FreeCourse.Shared.Services;
using MediatR;

namespace FreeCourse.Services.Basket.Aplication.Services.Features.BasketFeature.Commands.DeleteBasket
{
    public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommandRequest, DeleteBasketCommandResponse>
    {
        private readonly IBasketWriteRepository _basketWriteRepository;
        private readonly ISharedIdentityService _sharedIdentityService;
        public DeleteBasketCommandHandler(IBasketWriteRepository basketWriteRepository, ISharedIdentityService sharedIdentityService)
        {
            _basketWriteRepository = basketWriteRepository;
            _sharedIdentityService = sharedIdentityService;
        }

        public async Task<DeleteBasketCommandResponse> Handle(DeleteBasketCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _basketWriteRepository.DeleteAsync(_sharedIdentityService.GetUserId);
            if (result)
                return new()
                {
                    Message="Deletion Successful",
                    StatusCode =200
                };
            return new()
            {
                Message = "Basket could not found",
                StatusCode =404
            };
        }
    }
}
