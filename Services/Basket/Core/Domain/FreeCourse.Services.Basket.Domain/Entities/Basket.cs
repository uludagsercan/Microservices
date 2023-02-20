using FreeCourse.Services.Basket.Domain.Entities.Common;

namespace FreeCourse.Services.Basket.Domain.Entities
{
    public class Basket:BaseEntity
    {
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public decimal TotalPrice => BasketItems.Sum(x => x.Quantity * x.Price);
    }
}
