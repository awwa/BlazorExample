using HogeBlazor.Server.Db;
using HogeBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HogeBlazor.Server.Repository;

public class WeatherForecastRepository : IWeatherForecastRepository
{
    private readonly AppDbContext _context;

    public WeatherForecastRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<WeatherForecast>> GetWeatherForecasts()
    {
        return await _context.WeatherForecasts.ToListAsync();
    }
}
