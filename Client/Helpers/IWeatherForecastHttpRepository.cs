
namespace HogeBlazor.Client.Helpers;

public interface IWeatherForecastHttpRepository
{
    Task<List<WeatherForecast>> GetForecasts();
}