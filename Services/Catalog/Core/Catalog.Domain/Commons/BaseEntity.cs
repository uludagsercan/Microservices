using FreeCourse.Shared.Entities.Commons;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Domain.Commons
{
    public class BaseEntity:IEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
