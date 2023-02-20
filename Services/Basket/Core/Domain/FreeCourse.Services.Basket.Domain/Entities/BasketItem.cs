using FreeCourse.Services.Basket.Domain.Entities.Common;

namespace FreeCourse.Services.Basket.Domain.Entities
{
    public class BasketItem:BaseEntity
    {
        public int Quantity { get; set; }
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public decimal Price { get; set; }
    }
}
