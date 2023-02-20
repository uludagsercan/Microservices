using FreeCourse.Services.Basket.Domain.Entities;
using MediatR;

namespace FreeCourse.Services.Basket.Aplication.Services.Features.BasketFeature.Commands.CreateOrUpdateBasket
{
    public class CreateOrUpdateCommandRequest : IRequest<CreateOrUpdateCommandResponse>
    {
        public string DiscountCode { get; set; }
        public List<BasketItem> BasketItems { get; set; }
    }
}
