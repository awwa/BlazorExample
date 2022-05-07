
using HogeBlazor.Client.Helpers;

namespace HogeBlazor.Client.Repositories;

public interface IWeatherForecastHttpRepository
{
    Task<List<WeatherForecast>> GetForecasts();
}