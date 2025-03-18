using BitePaper.Infrastructure.Interfaces.Auth;
using BitePaper.Models.DTOs.Request.Auth;
using FastEndpoints;

namespace BitePaper.Api.Controllers.Auth;

public class LoginEndpoint : Endpoint<LoginDto>
{
    private readonly IAuthService _authService;
    private readonly ILogger<LoginEndpoint> _logger;

    public LoginEndpoint(IAuthService authService, ILogger<LoginEndpoint> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    public override void Configure()
    {
        Post("/auth/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginDto req, CancellationToken ct)
    {
        var token = await _authService.LoginAsync(req);

        if (string.IsNullOrEmpty(token) || token == "User not found" || token == "Invalid password or email")
        {
            await SendAsync(new { message = token }, StatusCodes.Status400BadRequest, ct);
            return;
        }

        await SendAsync(new { token }, StatusCodes.Status200OK, ct);
    }
}