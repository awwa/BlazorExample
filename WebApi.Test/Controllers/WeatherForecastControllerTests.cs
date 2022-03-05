using WebApi.Controllers;
using Xunit;
using System.Net;
using System.Net.Http;
using System.Diagnostics;

namespace WebApi.Test;

public class WeatherForecastControllerTest
{
    [Fact]
    public async void Test2()
    {
        var client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync("https://localhost:7299/WeatherForecast");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        Debug.WriteLine(responseBody);
    }
}