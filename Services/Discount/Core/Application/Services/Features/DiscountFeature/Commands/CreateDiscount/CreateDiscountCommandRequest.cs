using MediatR;

namespace Application.Services.Features.DiscountFeature.Commands.CreateDiscount
{
    public class CreateDiscountCommandRequest:IRequest<CreateDiscountCommandResponse>
    {
        public string UserId { get; set; }
        public int Rate { get; set; }
        public string Code { get; set; }
    }
}
