using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BitePaper.Models.Entities;
public class Step
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("step_order")]
    public int StepOrder { get; set; }
    [BsonElement("approver_id")]
    public string ApproverId { get; set; }
    [BsonElement("status")]
    public string StatusId { get; set; }
    [BsonElement("action_at")]
    public DateTime ActionAt { get; set; }
}
