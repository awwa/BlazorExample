using System.IdentityModel.Tokens.Jwt;
using System.Text;
using HogeBlazor.Server.Helpers;
using HogeBlazor.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace HogeBlazor.Server.Controllers;

[ApiController]
public class TokenController : ControllerBase
{
    // MS公式情報
    // https://docs.microsoft.com/ja-jp/aspnet/core/security/authentication/cookie?view=aspnetcore-6.0
    // をベースにして、よりわかりやすい以下の情報ベースで書き直した
    // https://zukucode.com/2020/11/aspnet-spa-auth.html
    [AllowAnonymous]
    [HttpPost]
    [Route(Const.API_BASE_PATH_V1 + "[controller]/login")]
    public async Task<IActionResult> Login([FromBody] AuthenticateRequest auth)
    {
        string email = auth.Email;
        string password = auth.PlainPassword;

        if (true)
        {
            // var claims = new List<Claim>
            // {
            //     new Claim(ClaimTypes.Name, email),
            //     // new Claim("FullName", user.FullName),
            //     new Claim(ClaimTypes.Role, "Administrator"),
            // };

            // var claimsIdentity = new ClaimsIdentity(
            //     claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // var authProperties = new AuthenticationProperties
            // {
            //     //AllowRefresh = <bool>,
            //     // Refreshing the authentication session should be allowed.

            //     //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
            //     // The time at which the authentication ticket expires. A 
            //     // value set here overrides the ExpireTimeSpan option of 
            //     // CookieAuthenticationOptions set with AddCookie.

            //     //IsPersistent = true,
            //     // Whether the authentication session is persisted across 
            //     // multiple requests. When used with cookies, controls
            //     // whether the cookie's lifetime is absolute (matching the
            //     // lifetime of the authentication ticket) or session-based.

            //     //IssuedUtc = <DateTimeOffset>,
            //     // The time at which the authentication ticket was issued.

            //     //RedirectUri = <string>
            //     RedirectUri = "/fetchdata",
            //     // The full path or absolute URI to be used as an http 
            //     // redirect response value.                
            // };

            // await HttpContext.SignInAsync(
            //     CookieAuthenticationDefaults.AuthenticationScheme,
            //     new ClaimsPrincipal(claimsIdentity),
            //     authProperties);

            Console.WriteLine($"User {email} logged in.");
            var token = GenerateToken(email);
            var tokenResp = new TokenResponse() { Token = token };
            //return Ok(tokenResp);

            // ASP.NET jwtの認証トークンをcookieで保持する方法
            // https://zukucode.com/2021/04/aspnet-jwt-cookie.html
            Response.Cookies.Append("X-Access-Token", token, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Lax, Secure = true });
            return Ok(tokenResp);

            // var token = BuildToken();
            // var tokenResp = new TokenResponse() { Token = token };
            // return Ok(tokenResp);
        }
        else
        {
            return Unauthorized();
        }
        // var query = _context.Users.AsQueryable();
        // var user = await query.Where(x => x.Email == auth.Email).FirstOrDefaultAsync<User>();
        // if (user == null) return Unauthorized();
        // if (user.Authenticate(auth.PlainPassword))
        // {
        //     Console.WriteLine("未認証なのでJWTを生成して返す");
        //     string token = JWTHelper.Encode(user);
        //     var tokenResp = new TokenResponse() { Token = token };
        //     return Ok(tokenResp);
        // }
        // else
        // {
        //     return Unauthorized();
        // }
    }

    [HttpPost]
    [Route(Const.API_BASE_PATH_V1 + "[controller]/logout")]
    public async Task<IActionResult> Logout(string? returnUrl = null)
    {
        // if (!string.IsNullOrEmpty("ErrorMessage"))
        // {
        //     ModelState.AddModelError(string.Empty, "ErrorMessage");
        // }

        // Clear the existing external cookie
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok();
        //ReturnUrl = returnUrl;
    }

    private string GenerateToken(string userid)
    {
        var claims = new[] {
            // 必要な認証情報を追加する
            new Claim(ClaimTypes.Name, userid)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890abcdefg"));
        var token = new JwtSecurityToken(
            "hoge", // issuer
            "fuga", // audience
            claims,
            expires: DateTime.Now.AddSeconds(10000), // 有効期限
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256) // Startup.csで設定したものと同じ値を設定
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    // private string GenerateToken()
    // {
    //     var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890abcdefg"));
    //     var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    //     var token = new JwtSecurityToken(
    //         issuer: "hoge",
    //         audience: "fuga",
    //         expires: DateTime.Now.AddMinutes(30),
    //         signingCredentials: creds
    //     );

    //     return new JwtSecurityTokenHandler().WriteToken(token);
    // }
}