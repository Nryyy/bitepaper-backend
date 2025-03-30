using System.ComponentModel.DataAnnotations;

namespace BitePaper.Models.DTOs.Request.Auth;

public class RefreshTokenRequest
{
    [Required(ErrorMessage = "Refresh token is required.")]
    public string RefreshToken { get; set; } = string.Empty;
} 