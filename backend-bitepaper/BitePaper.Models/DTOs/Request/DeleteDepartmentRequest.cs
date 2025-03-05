using MongoDB.Bson;

namespace BitePaper.Models.DTOs.Request;

public class DeleteDepartmentRequest
{
    public ObjectId Id { get; set; }
}