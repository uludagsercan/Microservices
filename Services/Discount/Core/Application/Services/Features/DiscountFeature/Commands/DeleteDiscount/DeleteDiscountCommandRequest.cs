using MediatR;

namespace Application.Services.Features.DiscountFeature.Commands.DeleteDiscount
{
    public class DeleteDiscountCommandRequest:IRequest<DeleteDiscountCommandResponse>
    {
        public string Id { get; set; }
    }
}
