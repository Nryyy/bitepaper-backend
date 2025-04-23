using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BitePaper.Models.Entities;
public class Document
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("title")]
    public string Title { get; set; } = string.Empty;

    [BsonElement("author_id")]
    public string AuthorId { get; set; } = string.Empty;

    [BsonElement("status")]
    public Status Status { get; set; } = null!;

    [BsonElement("file_id")]
    public string FileId { get; set; } = string.Empty;

    [BsonElement("file_type")]
    public string FileType { get; set; } = string.Empty;

    [BsonElement("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [BsonElement("updated_at")]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}