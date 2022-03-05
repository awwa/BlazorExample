using WebApi.Controllers;
using Xunit;
using System.Net;
using System.Net.Http;
using System.Diagnostics;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Test;

public class WeatherForecastControllerTest
{
    private readonly HttpClient _client;

    // https://docs.microsoft.com/ja-jp/aspnet/core/test/integration-tests?view=aspnetcore-6.0
    public WeatherForecastControllerTest()
    {
        var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder => 
            {
                builder.UseSetting("https_port", "7229");
            });
        _client = application.CreateClient();
    }

    [Fact]
    public async void Test2()
    {
        HttpResponseMessage response = await _client.GetAsync("/WeatherForecast");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        Debug.WriteLine(responseBody);
    }
}