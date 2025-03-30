using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BitePaper.Models.Entities
{
    public class Status
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
    }
}
