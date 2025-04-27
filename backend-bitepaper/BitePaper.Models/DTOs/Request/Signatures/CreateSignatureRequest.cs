namespace BitePaper.Models.DTOs.Request.Signatures
{
    public class CreateSignatureRequest
    {
        public string DocumentId { get; set; }

        public string UserId { get; set; }
        public string SignatureData { get; set; }
    }
}
