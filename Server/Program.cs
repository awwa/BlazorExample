using HogeBlazor.Server.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication;
using System.Text;
using Microsoft.AspNetCore.Identity;
using HogeBlazor.Server.Models;
using HogeBlazor.Shared.Models.Db;
using HogeBlazor.Server.Repositories;
using HogeBlazor.Server.Db;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

// Blazor WebAssembly Authentication with ASP.NET Core Identity
// https://code-maze.com/blazor-webassembly-authentication-aspnetcore-identity/
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
builder.Services.AddRazorPages();
builder.Services.AddOpenApiDocument();

// PostgreSQLの設定
string npgsqlConnString = builder.Configuration.GetConnectionString("PostgresDatabase");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(connectionString: npgsqlConnString)
);

// ControllerのURLを小文字に変換
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// リポジトリの登録
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
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

app.UseOpenApi();
app.UseSwaggerUi3();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapDefaultControllerRoute();
app.MapFallbackToFile("index.html");

app.Run();

public partial class Program { }