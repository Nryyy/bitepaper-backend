using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BitePaper.Models.Entities
{
    public class Signature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("document_id")]
        public string DocumentId { get; set; } = string.Empty;
        [BsonElement("user_id")]
        public string UserId { get; set; } = string.Empty;
        [BsonElement("signature_type")]
        public string SignatureData { get; set; } = string.Empty;
        [BsonElement("signed_at")]
        public DateTime SignedAt { get; set; } = DateTime.Now;

    }
}
