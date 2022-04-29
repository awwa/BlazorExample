using HogeBlazor.Client.Helpers;
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
        // @*Console.WriteLine(HostEnvironment.BaseAddress); *@
        // @*HostEnvironment.BaseAddressはBlazor WASMが配布されているサイトのURL *@
        // @*forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast"); *@
        // @*TODO 本来ログインはログイン画面で行う。とりあえずAPIの動作確認のため強制ログイン *@
        // @*var httpClient = new HttpClient();
        // var authClient = new AuthClient(HostEnvironment.BaseAddress, httpClient);
        // var authRequest = new AuthenticateRequest() { Email = "admin@hogeblazor", PlainPassword = "password" };
        // var resp = await authClient.LoginAsync(authRequest);
        // var weatherClient = new WeatherForecastClient(HostEnvironment.BaseAddress, httpClient);
        // var resp2 = await weatherClient.GetAsync();
        // var forecast2 = (List<WeatherForecast>)resp2;
        // forecasts = forecast2.ToArray<WeatherForecast>(); *@

        // @*var client = new WeatherForecastClient("/api/v1", Http);
        // var forecasts2 = (List<WeatherForecast>)(await client.GetAsync());
        // forecasts = forecasts2.ToArray(); *@
    }

    private async Task GetForecasts()
    {
        ForecastList = await WeatherForecastRepo.GetForecasts();
    }

    public void Dispose() => Interceptor.DisposeEvent();
}