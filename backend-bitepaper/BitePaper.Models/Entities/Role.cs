using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BitePaper.Models.Entities
{
    public class Role
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
    }   
}
