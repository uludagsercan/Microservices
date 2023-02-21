using FreeCourse.Shared.Entities.Commons;

namespace Domain.Entities.Common
{
    public class BaseEntity : IEntity
    {
        public string Id { get; set; }
    }
}
