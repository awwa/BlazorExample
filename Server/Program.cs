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
using Microsoft.AspNetCore.Identity;
using HogeBlazor.Server.Models;
using HogeBlazor.Shared.Models;
using HogeBlazor.Server.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

// Blazor WebAssembly Authentication with ASP.NET Core Identity
// https://code-maze.com/blazor-webassembly-authentication-aspnetcore-identity/
// var jwtSettings = Configuration.Get
var jwtSettings = new JWTSettings();
builder.Configuration.GetSection("JWTSettings").Bind(jwtSettings);

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = jwtSettings.ValidIssuer,
        ValidAudience = jwtSettings.ValidAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecurityKey))
    };
});

builder.Services.AddControllersWithViews();

// builder.Services.AddControllersWithViews(options =>
//     {
//       // すべてのアクセスに対してjwtの認証保護を適用する
//       options.Filters.Add(
//           new AuthorizeFilter(
//               new AuthorizationPolicyBuilder(
//                   JwtBearerDefaults.AuthenticationScheme
//               ).RequireAuthenticatedUser().Build()
//           )
//       );
//     });

// ASP.NET jwtのログイン認証を実装する
// https://zukucode.com/2021/04/aspnet-jwt-auth.html
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(options =>
//     {
//       var secret = builder.Configuration.GetValue<string>("AuthSecret");
//       var issuer = builder.Configuration.GetValue<string>("Issuer");
//       var audience = builder.Configuration.GetValue<string>("Audience");
//       options.TokenValidationParameters = new TokenValidationParameters()
//       {
//         ValidateIssuer = true,
//         ValidateAudience = true,
//         ValidateLifetime = true,
//         ValidateIssuerSigningKey = true,
//         ValidIssuer = issuer,
//         ValidAudience = audience,
//         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
//         ClockSkew = TimeSpan.Zero
//       };
//       options.Events = new JwtBearerEvents()
//       {
//         OnMessageReceived = context =>
//         {
//           if (context.Request.Cookies.ContainsKey("X-Access-Token"))
//           {
//                 // "X-Access-Tokenのcookieが存在する場合はこの値を認証トークンとして扱う
//             context.Token = context.Request.Cookies["X-Access-Token"];
//           }
//           return Task.CompletedTask;
//         }
//       };
//     });

builder.Services.AddRazorPages();
builder.Services.AddOpenApiDocument();

string connectionString = builder.Configuration.GetConnectionString("HogeBlazorDatabase");
// builder.Services.AddDbContext<HogeBlazorDbContext>(
//     options => options.UseMySql(connectionString: connectionString,
//             new MySqlServerVersion(new Version(8, 0, 28)))
// );
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySql(connectionString: connectionString,
            new MySqlServerVersion(new Version(8, 0, 28)))
);

//builder.Services.AddScoped<IProductHttpRepository, ProductHttpRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ITokenService, TokenService>();

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

//app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseOpenApi();

app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapDefaultControllerRoute();
app.MapFallbackToFile("index.html");

app.Run();

public partial class Program { }