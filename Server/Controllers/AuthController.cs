// using System.IdentityModel.Tokens.Jwt;
// using System.Text;
// using HogeBlazor.Server.Helpers;
// using HogeBlazor.Shared.Models;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.IdentityModel.Tokens;
// using Microsoft.AspNetCore.Authentication.Cookies;
// using Microsoft.EntityFrameworkCore;
// using System.Security.Claims;
// using System.Text.Json;

// namespace HogeBlazor.Server.Controllers;

// [ApiController]
// public class AuthController : ControllerBase
// {
//     private readonly ProductContext _context = default!;
//     private readonly ILogger<UsersController> _logger = default!;
//     private readonly IConfiguration _configuration;

//     public AuthController(ProductContext context, ILogger<UsersController> logger, IConfiguration configuration)
//     {
//         _context = context;
//         _logger = logger;
//         _configuration = configuration;
//     }

//     // MS公式情報
//     // https://docs.microsoft.com/ja-jp/aspnet/core/security/authentication/cookie?view=aspnetcore-6.0
//     // をベースにして、よりわかりやすい以下の情報ベースで書き直した
//     // https://zukucode.com/2020/11/aspnet-spa-auth.html
//     [AllowAnonymous]
//     [HttpPost]
//     [Route(Const.API_BASE_PATH_V1 + "[controller]/login")]
//     public async Task<IActionResult> Login([FromBody] AuthenticateRequest auth)
//     {
//         var query = _context.Users.AsQueryable();
//         var user = await query.Where(x => x.Email == auth.Email).FirstOrDefaultAsync<User>();
//         if (user == null) return Unauthorized();
//         if (user.Authenticate(auth.PlainPassword))
//         {
//             var token = GenerateToken(user);
//             var tokenResp = new TokenResponse() { Token = token };
//             string json = JsonSerializer.Serialize(tokenResp);
//             // ASP.NET jwtの認証トークンをcookieで保持する方法
//             // https://zukucode.com/2021/04/aspnet-jwt-cookie.html
//             Response.Cookies.Append(
//                 "X-Access-Token",
//                 token,
//                 new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Lax, Secure = true });
//             return Ok(json);
//         }
//         else
//         {
//             Console.WriteLine("Unauthorized");
//             return Unauthorized();
//         }
//     }

//     [HttpPost]
//     [Route(Const.API_BASE_PATH_V1 + "[controller]/logout")]
//     public async Task<IActionResult> Logout(string? returnUrl = null)
//     {
//         // Clear the existing external cookie
//         await HttpContext.SignOutAsync(
//             CookieAuthenticationDefaults.AuthenticationScheme);
//         return Ok();
//     }

//     /// <summary>
//     /// JWTトークンの構築
//     /// </summary>
//     /// <param name="user">ユーザー情報</param>
//     /// <returns></returns>
//     private string GenerateToken(User user)
//     {
//         List<Claim> claims = ClaimsHelper.UserToClaims(user);
//         var secret = _configuration.GetValue<string>("AuthSecret");
//         var issuer = _configuration.GetValue<string>("Issuer");
//         var audience = _configuration.GetValue<string>("Audience");
//         var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
//         var token = new JwtSecurityToken(
//             issuer,
//             audience,
//             claims.ToArray<Claim>(),
//             expires: DateTime.Now.AddMinutes(30),
//             signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
//         );
//         return new JwtSecurityTokenHandler().WriteToken(token);
//     }
// }