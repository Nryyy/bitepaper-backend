using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BitePaper.Models.Entities;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
    [BsonElement("Email")]
    public string Email { get; set; } = string.Empty;
    [BsonElement("PasswordHash")]
    public string PasswordHash { get; set; } = string.Empty;
    [BsonElement("Role")]
    public Role Role { get; set; } = null!;
    [BsonElement("FullName")]
    public string FullName { get; set; } = string.Empty;
    [BsonElement("DateOfBirth")]
    public DateTime? DateOfBirth { get; set; } = null;
    [BsonElement("GoogleId")]
    public string GoogleId { get; set; } = string.Empty;
    [BsonElement("PictureUrl")]
    public string? PictureUrl { get; set; } = string.Empty;
    [BsonElement("CreatedAt")]
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    [BsonElement("UpdatedAt")]
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
}