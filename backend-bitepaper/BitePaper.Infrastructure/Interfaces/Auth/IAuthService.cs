using BitePaper.Models.DTOs.Request.Auth;
using BitePaper.Models.DTOs.Response.Auth;

namespace BitePaper.Infrastructure.Interfaces.Auth;

public interface IAuthService
{
    Task<AuthResponseDto?> RegisterAsync(RegisterDto request);
    Task<AuthResponseDto?> LoginAsync(LoginDto request);
    Task<AuthResponseDto?> RefreshTokenAsync(string refreshToken);
    Task RevokeTokenAsync(string refreshToken);
}