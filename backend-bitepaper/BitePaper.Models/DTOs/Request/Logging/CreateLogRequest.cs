namespace BitePaper.Models.DTOs.Request.Logs
{
    public class CreateLogRequest
    {
        public string UserId { get; set; }
        public string Action { get; set; }
        public string Details { get; set; }
    }
}
