using BitePaper.Models.DTOs.Request.Auth;

namespace BitePaper.Infrastructure.Interfaces.Auth;

public interface IAuthService
{
    Task<string?> RegisterAsync(RegisterDto request);
    Task<string?> LoginAsync(LoginDto request);
}