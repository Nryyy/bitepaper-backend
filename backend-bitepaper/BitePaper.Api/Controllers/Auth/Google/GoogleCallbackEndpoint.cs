using FastEndpoints;
using Microsoft.AspNetCore.Authentication;

namespace BitePaper.Api.Controllers.Auth.Google;

public class GoogleCallbackEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/auth/google-callback");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await HttpContext.AuthenticateAsync();
        if (!result.Succeeded)
        {
            await SendAsync(new { error = "Authentication failed" }, cancellation: ct);
            return;
        }

        var claims = result.Principal?.Claims.ToDictionary(c => c.Type, c => c.Value);
        await SendAsync(claims ?? new Dictionary<string, string>(), cancellation: ct);
    }
}