using HogeBlazor.Shared.Models;

namespace HogeBlazor.Server.Repositories;

public interface IWeatherForecastRepository
{
    Task<List<WeatherForecast>> GetWeatherForecasts();
}
