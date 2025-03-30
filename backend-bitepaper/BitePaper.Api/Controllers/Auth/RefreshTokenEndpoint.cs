using BitePaper.Infrastructure.Interfaces.Auth;
using BitePaper.Models.DTOs.Request.Auth;
using BitePaper.Models.DTOs.Response.Auth;
using FastEndpoints;

namespace BitePaper.Api.Controllers.Auth;

public class RefreshTokenEndpoint : Endpoint<RefreshTokenRequest>
{
    private readonly IAuthService _authService;
    private readonly ILogger<RefreshTokenEndpoint> _logger;

    public RefreshTokenEndpoint(IAuthService authService, ILogger<RefreshTokenEndpoint> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    public override void Configure()
    {
        Post("/auth/refresh-token");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RefreshTokenRequest req, CancellationToken ct)
    {
        var response = await _authService.RefreshTokenAsync(req.RefreshToken);

        if (response == null)
        {
            await SendAsync(new { message = "Invalid refresh token" }, StatusCodes.Status401Unauthorized, ct);
            return;
        }

        await SendAsync(response, StatusCodes.Status200OK, ct);
    }
} 