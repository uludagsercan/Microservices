namespace FreeCourse.Services.Order.Application.Features.OrderFeature.Dtos
{
    public class CreateOrderDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public AddressDto Address { get; set; }
        public string BuyerId { get; set; }
    }
}
