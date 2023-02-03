using Catalog.Domain.Commons;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Domain.Entities
{
    public class Course:BaseEntity
    {
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public string Picture { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime CreatedDate { get; set; }
        public Feature Feature { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string CategoryId { get; set; }
        [BsonIgnore]
        public Category Category { get; set; }
    }
}
