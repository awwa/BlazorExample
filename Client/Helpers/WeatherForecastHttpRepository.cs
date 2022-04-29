
namespace HogeBlazor.Client.Helpers;

public class WeatherForecastHttpRepository : IWeatherForecastHttpRepository
{
    private readonly HttpClient _client;

    public WeatherForecastHttpRepository(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<WeatherForecast>> GetForecasts()
    {
        var f = new WeatherForecastsClient("", _client);
        return (List<WeatherForecast>)await f.GetAsync();
    }
}