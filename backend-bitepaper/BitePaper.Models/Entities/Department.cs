using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BitePaper.Models.Entities;

public class Department
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }
    
    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;
    
    [BsonElement("head")]
    public string Head { get; set; } = string.Empty;
}