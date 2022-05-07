using HogeBlazor.Client.Helpers;
using HogeBlazor.Client.Repositories;
using HogeBlazor.Client.Services;
using Microsoft.AspNetCore.Components;

namespace HogeBlazor.Client.Pages;

public partial class FetchData : IDisposable
{
    public List<WeatherForecast> ForecastList { get; set; } = new List<WeatherForecast>();

    [Inject]
    public IWeatherForecastHttpRepository WeatherForecastRepo { get; set; } = default!;

    [Inject]
    public HttpInterceptorService Interceptor { get; set; } = default!;


    protected override async Task OnInitializedAsync()
    {
        Interceptor.RegisterEvent();
        await GetForecasts();
    }

    private async Task GetForecasts()
    {
        ForecastList = await WeatherForecastRepo.GetForecasts();
    }

    public void Dispose() => Interceptor.DisposeEvent();
}