using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using HogeBlazor.Server.Repositories;
using HogeBlazor.Server.Test.Repositories;
using HogeBlazor.Shared.Models.Dto;

namespace HogeBlazor.Server.Test.Controllers;

public class CarsControllerTests
{
    private HttpClient getClientWithMockDefault()
    {
        return new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<ICarRepository, MockDynamoCarRepository>();
                });
            }).CreateClient();
    }

    [Fact]
    public async void GetCarAsyncReturnsValidValue()
    {
        // Arrange
        var client = getClientWithMockDefault();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars/car_1");
        var response = await client.SendAsync(request);
        // Assert(Mockが返す結果を検証)
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(responseBody);
        var actual = JsonConvert.DeserializeObject<CarDto>(responseBody);
        Assert.Equal("car_1", actual!.Id);
        Assert.Equal("マツダ", actual!.MakerName);
        Assert.Equal("CX-5", actual!.ModelName);
    }

    [Fact]
    public async void QueryCarsAyncReturnsValidValue()
    {
        // Arrange
        var client = getClientWithMockDefault();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars?makerNames=マツダ");
        var response = await client.SendAsync(request);
        // Assert(Mockが返す結果を検証)
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(responseBody);
        var actual = JsonConvert.DeserializeObject<Dictionary<string, CarDto>>(responseBody);
        Assert.Single(actual);
        Assert.True(actual!.ContainsKey("car_1"));
        Assert.Equal("car_1", actual!["car_1"].Id);
        Assert.Equal("マツダ", actual!["car_1"].MakerName);
        Assert.Equal("CX-5", actual!["car_1"].ModelName);
    }

    [Fact]
    public async void QueryCarsAyncReturnsInvalidValue()
    {
        // Arrange
        var client = getClientWithMockDefault();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars?hoge=マツダ");
        var response = await client.SendAsync(request);
        // Assert(Mockが返す結果を検証)
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(responseBody);
        var actual = JsonConvert.DeserializeObject<Dictionary<string, CarDto>>(responseBody);
        Assert.Single(actual);
        Assert.True(actual!.ContainsKey("car_1"));
        Assert.Equal("car_1", actual!["car_1"].Id);
        Assert.Equal("マツダ", actual!["car_1"].MakerName);
        Assert.Equal("CX-5", actual!["car_1"].ModelName);
    }

    [Fact]
    public async void GetAttributeValuesAsync()
    {
        // Arrange
        var client = getClientWithMockDefault();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars/attributes?dataType=MakerName");
        var response = await client.SendAsync(request);
        // Assert(Mockが返す結果を検証)
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(responseBody);
        var actual = JsonConvert.DeserializeObject<List<string>>(responseBody);
        Assert.Contains<string>("マツダ", actual!);
        Assert.Contains<string>("トヨタ", actual!);
        Assert.Contains<string>("日産", actual!);
    }
}
