using BitePaper.Infrastructure.Interfaces.Auth;
using BitePaper.Models.DTOs.Request.Auth;
using FastEndpoints;

namespace BitePaper.Api.Controllers.Auth;

public class RegisterEndpoint : Endpoint<RegisterDto>
{
    private readonly IAuthService _authService;
    private readonly ILogger<RegisterEndpoint> _logger;

    public RegisterEndpoint(IAuthService authService, ILogger<RegisterEndpoint> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    public override void Configure()
    {
        Post("/auth/register");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RegisterDto req, CancellationToken ct)
    {
        var result = await _authService.RegisterAsync(req);

        if (result != "Registration successful!")
        {
            await SendAsync(new { message = result }, StatusCodes.Status400BadRequest, ct);
            return;
        }

        await SendAsync(new { message = result }, StatusCodes.Status201Created, ct);
    }
}