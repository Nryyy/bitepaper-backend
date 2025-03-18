using System.ComponentModel.DataAnnotations;

namespace BitePaper.Models.DTOs.Request.Auth;

public class RegisterDto
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required.")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Full name is required.")]
    public string FullName { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; } = null;

    [Required(ErrorMessage = "Google ID is required.")]
    public string GoogleId { get; set; } = string.Empty;

    public string? PictureUrl { get; set; } = string.Empty;

    [Required(ErrorMessage = "Role is required.")]
    public Entities.Role Role { get; set; } = null!;
}