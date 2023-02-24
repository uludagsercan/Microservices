using FreeCourse.Services.Order.Domain.Core;

namespace FreeCourse.Services.Order.Domain.OrderAggregate
{
    public class Order:Entity,IAggregateRoot
    {
        public DateTime CreatedDate { get; private set; }
        public Address Address { get; private set; }
        public string BuyerId { get; private set; }
        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
        public Order()
        {

        }
        public Order(Address address, string buyerId)
        {
            Address = address;
            BuyerId = buyerId;
            CreatedDate = DateTime.Now;
            _orderItems = new();
        }

        public decimal GetTotalPrice => _orderItems.Sum(x=> x.Price);
        public void AddOrderItem(string productId,string productName, decimal price, string pictureUrl)
        {
            var existProdcut = _orderItems.Any(x => x.ProductId == productId);
            if (!existProdcut)
            {
                var newOrderItem = new OrderItem(productId,productName,pictureUrl,price);
                _orderItems.Add(newOrderItem);
            }
        }
    }
}
