using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BitePaper.Models.Entities;
    public class ApprovalFlow
    {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
    [BsonElement("document_id")]
    public string DocumentId { get; set; } = string.Empty;
    [BsonElement("step_id")]
    public List<Step> Steps { get; set; } = new List<Step>();

}
