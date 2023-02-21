using MediatR;

namespace Application.Services.Features.DiscountFeature.Commands.UpdateDiscount
{
    public class UpdateDiscountCommandRequest:IRequest<UpdateDiscountCommandResponse>
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public int Rate { get; set; }
        public string Code { get; set; }
    }
}
