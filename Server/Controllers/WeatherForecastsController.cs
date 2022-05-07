using Microsoft.AspNetCore.Mvc;
using HogeBlazor.Shared.Models;
using HogeBlazor.Server.Helpers;
using Microsoft.AspNetCore.Authorization;
using HogeBlazor.Server.Repositories;

namespace HogeBlazor.Server.Controllers;

[Route($"{Const.API_BASE_PATH_V1}[controller]")]
[ApiController]
[Authorize(Roles = "Administrator")]
public class WeatherForecastsController : ControllerBase
{
    private readonly IWeatherForecastRepository _repo;
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    // private readonly ILogger<WeatherForecastController> _logger;
    // private readonly AppDbContext _context;
    // public WeatherForecastController(ILogger<WeatherForecastController> logger)
    // {
    //     _logger = logger;
    // }

    public WeatherForecastsController(IWeatherForecastRepository repo)
    {
        _repo = repo;
        // _context = context;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<WeatherForecast>))]
    public async Task<ActionResult<List<WeatherForecast>>> Get()
    {
        var forecasts = await _repo.GetWeatherForecasts();
        return Ok(forecasts);
        //_logger.LogInformation("Hoge Get");
        // await _context.Database.EnsureCreatedAsync();

        // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        // {
        //     Date = DateTime.Now.AddDays(index),
        //     TemperatureC = Random.Shared.Next(-20, 55),
        //     Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        // })
        // .ToArray();
    }
}
