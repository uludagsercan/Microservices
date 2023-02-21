using Domain.Entities.Common;

namespace Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("discount")]
    public class Discount:BaseEntity
    {
        public string UserId { get; set; }
        public int Rate { get; set; }
        public string Code { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
