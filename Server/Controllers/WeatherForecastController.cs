using Microsoft.AspNetCore.Mvc;
using HogeBlazor.Shared.Models;
using HogeBlazor.Server.Helpers;

namespace HogeBlazor.Server.Controllers;

[ApiController]
[Route($"{Const.API_BASE_PATH_V1}[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    // private readonly ILogger<WeatherForecastController> _logger;
    private readonly ProductContext _context;

    // public WeatherForecastController(ILogger<WeatherForecastController> logger)
    // {
    //     _logger = logger;
    // }

    public WeatherForecastController(ProductContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        //_logger.LogInformation("Hoge Get");
        // await _context.Database.EnsureCreatedAsync();

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
