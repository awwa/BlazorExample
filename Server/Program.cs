using Microsoft.AspNetCore.ResponseCompression;
using System.Diagnostics;
using Pomelo.EntityFrameworkCore.MySql;
using HogeBlazor.Server.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

//builder.Services.AddDbContext<HogeBlazorDbContext>();


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddOpenApiDocument();

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
builder.Configuration.AddConfiguration(configuration);
string connectionString = builder.Configuration.GetConnectionString("HogeBlazorDatabase");
builder.Services.AddDbContext<HogeBlazorDbContext>(
    options => options.UseMySql(connectionString: connectionString,
            new MySqlServerVersion(new Version(8, 0, 28))
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseOpenApi();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

public partial class Program { }