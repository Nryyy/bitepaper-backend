using FastEndpoints;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;

namespace BitePaper.Api.Controllers.Auth;

public class GoogleAuthEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/auth/google");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            var claims = User.Claims.ToDictionary(c => c.Type, c => c.Value);
            await SendAsync(claims, cancellation: ct);
            return;
        }

        await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties
        {
            RedirectUri = "/auth/google-callback"
        });
    }
}