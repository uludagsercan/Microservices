using MediatR;

namespace Application.Services.Features.DiscountFeature.Commands.CreateDiscount
{
    public class CreateDiscountCommandRequest:IRequest<CreateDiscountCommandResponse>
    {
        public string UserId { get; set; }
        public string Rate { get; set; }
        public string Code { get; set; }
    }
}
