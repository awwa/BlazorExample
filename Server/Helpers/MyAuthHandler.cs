// using System.Text.Encodings.Web;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.Extensions.Options;

using System.Security.Claims;
using System.Text.Encodings.Web;
using HogeBlazor.Server.Helpers;
using HogeBlazor.Shared.Models;
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

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        try
        {
            if (!this.Context.Request.Headers.TryGetValue("Authorization", out var bearerToken))
            {
                return await Task.FromResult(AuthenticateResult.Fail("fuga"));
            }
            var authVal = bearerToken.ToString().Split(' ');
            if (authVal.Length != 2)
            {
                return await Task.FromResult(AuthenticateResult.Fail("Authorizationヘッダ値のフォーマットが不正です。`Authorization: Bearer [token]`の形式で指定してください。"));
            }
            string token = authVal[1];
            User user = JWTHelper.Decode(token);
            var p = new ClaimsPrincipal(new ClaimsIdentity(new[]
                {
                    new Claim("hoge", "fuga"),
                },
                "JWT")
            );
            return await Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(p, "Api")));
        }
        catch (Exception ex)
        {
            return await Task.FromResult(AuthenticateResult.Fail($"予期しない例外が発生しました。{ex.Message}"));
        }
        //         (bool ok, string name) tryGetApiKey(HttpContext context)
        //         {
        //             if (!context.Request.Headers.TryGetValue("API_KEY", out var apiKey))
        //             {
        //                 return (false, "");
        //             }

        //             return apiKey.ToString() switch
        //             {
        //                 "A" => (true, "a さん"),
        //                 "B" => (true, "b さん"),
        //                 _ => (false, ""),
        //             };
        //         }

        //         var (ok, name) = tryGetApiKey(Context);

        //         if (!ok)
        //         {
        //             return Task.FromResult(AuthenticateResult.Fail("Invalid API Key"));
        //         }

        //         var p = new ClaimsPrincipal(new ClaimsIdentity(new[]
        //         {
        //     new Claim(ClaimTypes.Name, name),
        // }, "MyAuthType"));

        //         return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(
        //             p, "Api"
        //         )));
    }
}