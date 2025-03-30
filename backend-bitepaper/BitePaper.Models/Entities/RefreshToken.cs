using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BitePaper.Models.Entities;

public class RefreshToken
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [BsonElement("token")]
    public string Token { get; set; } = string.Empty;

    [BsonElement("userId")]
    public string UserId { get; set; } = string.Empty;

    [BsonElement("expiresAt")]
    public DateTime ExpiresAt { get; set; }

    [BsonElement("isRevoked")]
    public bool IsRevoked { get; set; }
} 