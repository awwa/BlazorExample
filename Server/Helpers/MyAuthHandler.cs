using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

class MyAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public MyAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock) : base(options, logger, encoder, clock)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        (bool ok, string name) tryGetApiKey(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("API_KEY", out var apiKey))
            {
                return (false, "");
            }

            return apiKey.ToString() switch
            {
                "A" => (true, "a さん"),
                "B" => (true, "b さん"),
                _ => (false, ""),
            };
        }

        var (ok, name) = tryGetApiKey(Context);

        if (!ok)
        {
            return Task.FromResult(AuthenticateResult.Fail("Invalid API Key"));
        }

        var p = new ClaimsPrincipal(new ClaimsIdentity(new[]
        {
        new Claim(ClaimTypes.Name, name),
    }, "MyAuthType"));

        return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(
            p, "Api"
        )));
    }
}