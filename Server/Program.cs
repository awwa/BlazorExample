using Microsoft.AspNetCore.ResponseCompression;
using System.Diagnostics;
using Pomelo.EntityFrameworkCore.MySql;
using HogeBlazor.Server.Helpers;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Add services to the container.
//var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
builder.Services.AddDbContext<HogeBlazorDbContext>(
    // options => options.UseSqlServer(
        // @"server=localhost;database=hoge_blazor;userid=root;password=password"//, 
        ///*new MySqlServerVersion(new Version(8, 0, 27)*/)
    //options => options.UseMySql(
//         "Server=localhost;User=root;Password=password;Database=hoge_blazor",
//         "auto"
//    )
);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

public partial class Program {}