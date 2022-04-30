using HogeBlazor.Shared.Models;

namespace HogeBlazor.Server.Repository;

public interface IWeatherForecastRepository
{
    Task<List<WeatherForecast>> GetWeatherForecasts();
}
