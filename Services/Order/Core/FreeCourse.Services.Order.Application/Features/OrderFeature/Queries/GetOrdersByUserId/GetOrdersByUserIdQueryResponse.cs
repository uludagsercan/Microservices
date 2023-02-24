using FreeCourse.Services.Order.Application.Features.OrderFeature.Dtos;

namespace FreeCourse.Services.Order.Application.Features.OrderFeature.Queries.GetOrdersByUserId
{
    public class GetOrdersByUserIdQueryResponse
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public AddressDto Address { get; set; }
        public string BuyerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
