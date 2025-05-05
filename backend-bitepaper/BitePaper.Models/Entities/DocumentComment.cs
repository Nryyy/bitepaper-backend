using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BitePaper.Models.Entities;

    public class DocumentComment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("document_id")]
        public string DocumentId { get; set; } = string.Empty;
        [BsonElement("user_id")]
        public string UserId { get; set; } = string.Empty;
        [BsonElement("comment")]
        public string Comment { get; set; } = string.Empty;
        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

