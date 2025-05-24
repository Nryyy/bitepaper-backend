namespace BitePaper.Models.DTOs.Request.Document;

public class UpdateDocumetRequest
{
    public string Id { get; set; }
    public List<string> UsersWithAccessEmail { get; set; } = new();
}