using Microsoft.AspNetCore.ResponseCompression;
using System.Diagnostics;
using Pomelo.EntityFrameworkCore.MySql;
using HogeBlazor.Server.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddControllersWithViews(options =>
    {
        // // すべてのアクセスに対して認証保護を適用する
        // options.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));
        // すべてのアクセスに対してjwtの認証保護を適用する
        options.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build()));
    });

// 以下のやり方を参考に追加
// https://qiita.com/okazuki/items/f66976c8cd71ea99c385
// builder.Services.AddAuthentication("Api")
//     .AddScheme<AuthenticationSchemeOptions, MyAuthHandler>("Api", options => { });
/////////////////////////////////////

// MS公式情報
// https://docs.microsoft.com/ja-jp/aspnet/core/security/authentication/cookie?view=aspnetcore-6.0
// をベースにして、よりわかりやすい以下の情報ベースで書き直した
// https://zukucode.com/2020/11/aspnet-spa-auth.html
// builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//     .AddCookie(options =>
//     {
//         options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
//         options.SlidingExpiration = true;
//         options.Events.OnRedirectToLogin = cxt =>
//         {
//             // ログイン画面に遷移するのではなくエラーを返す
//             cxt.Response.StatusCode = StatusCodes.Status401Unauthorized;
//             return Task.CompletedTask;
//         };
//         options.Events.OnRedirectToAccessDenied = cxt =>
//         {
//             // エラー画面に遷移するのではなくエラーを返す
//             cxt.Response.StatusCode = StatusCodes.Status403Forbidden;
//             return Task.CompletedTask;
//         };
//         options.Events.OnRedirectToLogout = cxt => Task.CompletedTask;
//         // options.AccessDeniedPath = "/Forbidden/";
//     });

// ASP.NET jwtのログイン認証を実装する
// https://zukucode.com/2021/04/aspnet-jwt-auth.html
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // var jwtConfig = new JwtConfig();
        // Configuration.Bind("Jwt", jwtConfig);
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "hoge",
            ValidAudience = "fuga",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890abcdefg")),
            ClockSkew = TimeSpan.Zero
        };
        options.Events = new JwtBearerEvents()
        {
            OnMessageReceived = context =>
            {
                Console.WriteLine($"Tokenある？ キー数：{context.Request.Cookies.Keys.Count}");
                foreach (var key in context.Request.Cookies.Keys) Console.WriteLine(key);
                if (context.Request.Cookies.ContainsKey("X-Access-Token"))
                {
                    // "X-Access-Tokenのcookieが存在する場合はこの値を認証トークンとして扱う
                    context.Token = context.Request.Cookies["X-Access-Token"];
                    Console.WriteLine(context.Token);
                }
                return Task.CompletedTask;
            }
        };
    });

// 以下のやり方を参考に追加
// https://blog.neno.dev/entry/2021/09/02/201156
// var keyBytes = new byte[64];
// RandomNumberGenerator.Fill(keyBytes);
// builder.Services
//     .AddAuthentication()
//     .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
//     {
//         Console.WriteLine("JwtBearerDefaults.AuthenticationScheme");
//         options.TokenValidationParameters = new TokenValidationParameters()
//         {
//             ValidateIssuerSigningKey = true,
//             ValidateLifetime = true,
//             ValidateIssuer = true,
//             ValidateAudience = false,
//             ValidIssuer = "hoge",
//             ValidAudience = "fuga",
//             IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
//         };
//     });
//////////////////////////////////////////////

builder.Services.AddRazorPages();
builder.Services.AddOpenApiDocument();

// var configuration = new ConfigurationBuilder()
//     .AddJsonFile("appsettings.json")
//     .Build();
// builder.Configuration.AddConfiguration(configuration);
string connectionString = builder.Configuration.GetConnectionString("HogeBlazorDatabase");
builder.Services.AddDbContext<HogeBlazorDbContext>(
    options => options.UseMySql(connectionString: connectionString,
            new MySqlServerVersion(new Version(8, 0, 28)))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseWebAssemblyDebugging();
    app.UseExceptionHandler("/error-development");
}
else
{
    app.UseExceptionHandler("/error");
    // app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseOpenApi();

// 以下のやり方を参考に追加
// https://blog.neno.dev/entry/2021/09/02/201156
// app.Map("/", async (HttpContext context) =>
// {
//     Console.WriteLine("auth endpoint");
//     var authResult = await context.AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme);
//     var principal = authResult.Principal;
//     Console.WriteLine(principal?.ToString());
//     var identity = principal?.Identity;
//     Console.WriteLine(identity?.ToString());

//     if (identity?.IsAuthenticated ?? false)
//     {
//         Console.WriteLine("認証済みであることを確認した");
//         var name = principal!.FindFirst(ClaimTypes.Name)!.Value;
//         return $"wellcome {name}";
//     }
//     else
//     {
//         Console.WriteLine("未認証なのでJWTを生成して返す");
//         var claims = new[] {
//             new Claim($"{ClaimTypes.UserData}/user/id", "1"),
//             new Claim($"{ClaimTypes.UserData}/user/name", "ほげ 太郎"),
//             new Claim($"{ClaimTypes.UserData}/user/email", "admin@example.com"),
//             new Claim($"{ClaimTypes.UserData}/user/role", "0"),
//             //new Claim(ClaimTypes.Name, "sample"),
//         };

//         var key = new SymmetricSecurityKey(keyBytes);
//         var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//         var header = new JwtHeader(credentials);
//         var issuer = "http://hoge-blazor/";
//         var audience = "http://hoge-blazor/";
//         var now = DateTime.Now;
//         var payload = new JwtPayload(issuer, audience, claims, now.AddSeconds(-5), now.AddMinutes(1));
//         var token = new JwtSecurityToken(header, payload);

//         var handler = new JwtSecurityTokenHandler();

//         return handler.WriteToken(token);
//     }
// });
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
//app.MapControllers();
app.MapDefaultControllerRoute();
app.MapFallbackToFile("index.html");
//app.UseMvc();

app.Run();

public partial class Program { }