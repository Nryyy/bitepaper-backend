using BitePaper.Infrastructure.Interfaces.Auth;
using BitePaper.Models.DTOs.Request.Auth;
using BitePaper.Models.DTOs.Response.Auth;
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
        var response = await _authService.LoginAsync(req);

        if (response == null)
        {
            await SendAsync(new { message = "Invalid credentials" }, StatusCodes.Status401Unauthorized, ct);
            return;
        }

        await SendAsync(response, StatusCodes.Status200OK, ct);
    }
}