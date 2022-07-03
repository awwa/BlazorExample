using HogeBlazor.Shared.Models;

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Microsoft.AspNetCore.Http.Json;
using HogeBlazor.Shared.Models.Db;
using Newtonsoft.Json;
using HogeBlazor.Server.Db;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using HogeBlazor.Server.Db.Configurations;
using System.Threading.Tasks;

namespace HogeBlazor.Server.Test.Controllers;

public class CarsControllerTests
{
    private readonly HttpClient _client;
    private AppDbContext _db;

    // ASP.NET Core での統合テスト
    // https://docs.microsoft.com/ja-jp/aspnet/core/test/integration-tests?view=aspnetcore-6.0
    public CarsControllerTests()
    {
        var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.UseSetting("http_port", "5000");
            });
        _client = application.CreateClient();

        // テスト用設定ファイルの読み込み
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        string npgsqlConnString = config.GetConnectionString("PostgresDatabase");
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(connectionString: npgsqlConnString);
        //optionsBuilder.LogTo(Console.WriteLine)/*.EnableSensitiveDataLogging()*/;   // 詳細ログの有効化
        _db = new AppDbContext(optionsBuilder.Options);
    }

    private async Task prepareTestData()
    {
        // 一旦全削除
        var qs = await _db.Cars.ToArrayAsync<Car>();
        _db.Cars.RemoveRange(qs);

        // テストデータ挿入
        var data = new List<Car>
        {
            CarConfiguration.Cx5(),
            CarConfiguration.Corolla(),
            CarConfiguration.Nsx(),
            CarConfiguration.HondaE(),
            CarConfiguration.Note(),
            CarConfiguration.Three(),
        };
        _db.Cars.AddRange(data);
        _db.SaveChanges();
    }

    //     /// <summary>
    //     /// ログイン
    //     /// </summary>
    //     /// <param name="email">メールアドレス</param>
    //     /// <param name="plainPassword">パスワード</param>
    //     /// <returns></returns>
    //     private async Task<string> Login(string email, string plainPassword)
    //     {
    //         var param = new Dictionary<string, object>()
    //         {
    //             ["email"] = email,
    //             ["plainPassword"] = plainPassword,
    //         };
    //         var jsonString = System.Text.Json.JsonSerializer.Serialize(param);
    //         var content = new StringContent(jsonString, Encoding.UTF8, @"application/json");
    //         HttpResponseMessage responseLogin = await _client.PostAsync("/api/v1/Auth/login", content);
    //         var responseLoginBody = await responseLogin.Content.ReadAsStringAsync();
    //         var token = JsonSerializer.Deserialize<TokenResponse>(responseLoginBody);
    //         return token!.Token;
    //     }

    #region GetCarsのテスト
    [Fact]
    public async void GetCarsReturnsCarListByMakerNames()
    {
        // Arrange
        await prepareTestData();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars?makerNames=マツダ&makerNames=ヒュンダイ&makerNames=トヨタ");
        var response = await _client.SendAsync(request);
        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        using (var responseStream = response.Content.ReadAsStream())
        using (var streamReader = new System.IO.StreamReader(responseStream))
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var serializer = JsonSerializer.Create();
            var actual = serializer.Deserialize<List<Car>>(jsonTextReader);
            if (actual == null)
            {
                Assert.False(true);
            }
            else
            {
                Assert.Equal(2, actual.Count);
                Assert.Equal("マツダ", actual[0].MakerName);
                Assert.Equal("トヨタ", actual[1].MakerName);
            }
        }
    }

    [Fact]
    public async void GetCarsReturnsCarListByPrice()
    {
        // Arrange
        await prepareTestData();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars?priceLower=3140500&priceUpper=4950000");
        var response = await _client.SendAsync(request);
        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        using (var responseStream = response.Content.ReadAsStream())
        using (var streamReader = new System.IO.StreamReader(responseStream))
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var serializer = JsonSerializer.Create();
            var actual = serializer.Deserialize<List<Car>>(jsonTextReader);
            if (actual == null)
            {
                Assert.False(true);
            }
            else
            {
                Assert.Equal(2, actual.Count);
                Assert.Equal("マツダ", actual[0].MakerName);
                Assert.Equal("CX-5", actual[0].ModelName);
                Assert.Equal("ホンダ", actual[1].MakerName);
                Assert.Equal("Honda e", actual[1].ModelName);
            }
        }
    }

    [Fact]
    public async void GetCarsReturnsCarListByPowerTrain()
    {
        // Arrange
        await prepareTestData();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars?powerTrain=ICE");
        var response = await _client.SendAsync(request);
        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        using (var responseStream = response.Content.ReadAsStream())
        using (var streamReader = new System.IO.StreamReader(responseStream))
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var serializer = JsonSerializer.Create();
            var actual = serializer.Deserialize<List<Car>>(jsonTextReader);
            if (actual == null)
            {
                Assert.False(true);
            }
            else
            {
                Assert.Equal(2, actual.Count);
                Assert.Equal("マツダ", actual[0].MakerName);
                Assert.Equal("CX-5", actual[0].ModelName);
                Assert.Equal("BMW", actual[1].MakerName);
                Assert.Equal("3シリーズツーリング", actual[1].ModelName);
            }
        }
    }

    [Fact]
    public async void GetCarsReturnsCarListByDriveSystem()
    {
        // Arrange
        await prepareTestData();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars?driveSystem=AWD");
        var response = await _client.SendAsync(request);
        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        using (var responseStream = response.Content.ReadAsStream())
        using (var streamReader = new System.IO.StreamReader(responseStream))
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var serializer = JsonSerializer.Create();
            var actual = serializer.Deserialize<List<Car>>(jsonTextReader);
            if (actual == null)
            {
                Assert.False(true);
            }
            else
            {
                Assert.Equal(5, actual.Count);
                Assert.Equal("マツダ", actual[0].MakerName);
                Assert.Equal("CX-5", actual[0].ModelName);
                Assert.Equal("トヨタ", actual[1].MakerName);
                Assert.Equal("カローラツーリング", actual[1].ModelName);
            }
        }
    }

    [Fact]
    public async void GetCarsReturnsCarListByBodyType()
    {
        // Arrange
        await prepareTestData();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars?bodyType=HATCHBACK");
        var response = await _client.SendAsync(request);
        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        using (var responseStream = response.Content.ReadAsStream())
        using (var streamReader = new System.IO.StreamReader(responseStream))
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var serializer = JsonSerializer.Create();
            var actual = serializer.Deserialize<List<Car>>(jsonTextReader);
            if (actual == null)
            {
                Assert.False(true);
            }
            else
            {
                Assert.Equal(2, actual.Count);
                Assert.Equal("ホンダ", actual[0].MakerName);
                Assert.Equal("Honda e", actual[0].ModelName);
                Assert.Equal("日産", actual[1].MakerName);
                Assert.Equal("ノート", actual[1].ModelName);
            }
        }
    }

    [Fact]
    public async void GetCarsReturnsCarListByLength()
    {
        // Arrange
        await prepareTestData();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars?lengthLower=4535&lengthUpper=4535");
        var response = await _client.SendAsync(request);
        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        using (var responseStream = response.Content.ReadAsStream())
        using (var streamReader = new System.IO.StreamReader(responseStream))
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var serializer = JsonSerializer.Create();
            var actual = serializer.Deserialize<List<Car>>(jsonTextReader);
            if (actual == null)
            {
                Assert.False(true);
            }
            else
            {
                Assert.Single(actual);
                Assert.Equal("ホンダ", actual[0].MakerName);
                Assert.Equal("NSX", actual[0].ModelName);
            }
        }
    }

    [Fact]
    public async void GetCarsReturnsCarListByWidth()
    {
        // Arrange
        await prepareTestData();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars?widthLower=1745&widthUpper=1840");
        var response = await _client.SendAsync(request);
        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        using (var responseStream = response.Content.ReadAsStream())
        using (var streamReader = new System.IO.StreamReader(responseStream))
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var serializer = JsonSerializer.Create();
            var actual = serializer.Deserialize<List<Car>>(jsonTextReader);
            if (actual == null)
            {
                Assert.False(true);
            }
            else
            {
                Assert.Equal(4, actual.Count);
                Assert.Equal("マツダ", actual[0].MakerName);
                Assert.Equal("CX-5", actual[0].ModelName);
                Assert.Equal("トヨタ", actual[1].MakerName);
                Assert.Equal("カローラツーリング", actual[1].ModelName);
                Assert.Equal("ホンダ", actual[2].MakerName);
                Assert.Equal("Honda e", actual[2].ModelName);
                Assert.Equal("BMW", actual[3].MakerName);
                Assert.Equal("3シリーズツーリング", actual[3].ModelName);
            }
        }
    }

    [Fact]
    public async void GetCarsReturnsCarListByHeight()
    {
        // Arrange
        await prepareTestData();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars?heightLower=1690&heightUpper=1690");
        var response = await _client.SendAsync(request);
        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        using (var responseStream = response.Content.ReadAsStream())
        using (var streamReader = new System.IO.StreamReader(responseStream))
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var serializer = JsonSerializer.Create();
            var actual = serializer.Deserialize<List<Car>>(jsonTextReader);
            if (actual == null)
            {
                Assert.False(true);
            }
            else
            {
                Assert.Single(actual);
                Assert.Equal("マツダ", actual[0].MakerName);
                Assert.Equal("CX-5", actual[0].ModelName);
            }
        }
    }

    [Fact]
    public async void GetCarsReturnsCarListByWeight()
    {
        // Arrange
        await prepareTestData();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars?weightUpper=1620");
        var response = await _client.SendAsync(request);
        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        using (var responseStream = response.Content.ReadAsStream())
        using (var streamReader = new System.IO.StreamReader(responseStream))
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var serializer = JsonSerializer.Create();
            var actual = serializer.Deserialize<List<Car>>(jsonTextReader);
            if (actual == null)
            {
                Assert.False(true);
            }
            else
            {
                Assert.Equal(4, actual.Count);
                Assert.Equal("マツダ", actual[0].MakerName);
                Assert.Equal("CX-5", actual[0].ModelName);
                Assert.Equal("トヨタ", actual[1].MakerName);
                Assert.Equal("カローラツーリング", actual[1].ModelName);
                Assert.Equal("ホンダ", actual[2].MakerName);
                Assert.Equal("Honda e", actual[2].ModelName);
                Assert.Equal("日産", actual[3].MakerName);
                Assert.Equal("ノート", actual[3].ModelName);
            }
        }
    }

    [Fact]
    public async void GetCarsReturnsCarListByDoorNum()
    {
        // Arrange
        await prepareTestData();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars?doorNumLower=3");
        var response = await _client.SendAsync(request);
        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        using (var responseStream = response.Content.ReadAsStream())
        using (var streamReader = new System.IO.StreamReader(responseStream))
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var serializer = JsonSerializer.Create();
            var actual = serializer.Deserialize<List<Car>>(jsonTextReader);
            if (actual == null)
            {
                Assert.False(true);
            }
            else
            {
                Assert.Equal(5, actual.Count);
                Assert.Equal("マツダ", actual[0].MakerName);
                Assert.Equal("CX-5", actual[0].ModelName);
                Assert.Equal("トヨタ", actual[1].MakerName);
                Assert.Equal("カローラツーリング", actual[1].ModelName);
                Assert.Equal("ホンダ", actual[2].MakerName);
                Assert.Equal("Honda e", actual[2].ModelName);
                Assert.Equal("日産", actual[3].MakerName);
                Assert.Equal("ノート", actual[3].ModelName);
                Assert.Equal("BMW", actual[4].MakerName);
                Assert.Equal("3シリーズツーリング", actual[4].ModelName);
            }
        }
    }

    [Fact]
    public async void GetCarsReturnsCarListByRidingCap()
    {
        // Arrange
        await prepareTestData();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars?ridingCapLower=4&ridingCapUpper=4");
        var response = await _client.SendAsync(request);
        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        using (var responseStream = response.Content.ReadAsStream())
        using (var streamReader = new System.IO.StreamReader(responseStream))
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var serializer = JsonSerializer.Create();
            var actual = serializer.Deserialize<List<Car>>(jsonTextReader);
            if (actual == null)
            {
                Assert.False(true);
            }
            else
            {
                Assert.Single(actual);
                Assert.Equal("ホンダ", actual[0].MakerName);
                Assert.Equal("Honda e", actual[0].ModelName);
            }
        }
    }

    [Fact]
    public async void GetCarsReturnsCarListByFcrWltc()
    {
        // Arrange
        await prepareTestData();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars?fcrWltcLower=13.0");
        var response = await _client.SendAsync(request);
        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        using (var responseStream = response.Content.ReadAsStream())
        using (var streamReader = new System.IO.StreamReader(responseStream))
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var serializer = JsonSerializer.Create();
            var actual = serializer.Deserialize<List<Car>>(jsonTextReader);
            if (actual == null)
            {
                Assert.False(true);
            }
            else
            {
                Assert.Equal(4, actual.Count);
                Assert.Equal("マツダ", actual[0].MakerName);
                Assert.Equal("CX-5", actual[0].ModelName);
                Assert.Equal("トヨタ", actual[1].MakerName);
                Assert.Equal("カローラツーリング", actual[1].ModelName);
                Assert.Equal("日産", actual[2].MakerName);
                Assert.Equal("ノート", actual[2].ModelName);
                Assert.Equal("BMW", actual[3].MakerName);
                Assert.Equal("3シリーズツーリング", actual[3].ModelName);
            }
        }
    }

    [Fact]
    public async void GetCarsReturnsCarListByFcrJc08()
    {
        // Arrange
        await prepareTestData();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars?fcrJc08Lower=14.2");
        var response = await _client.SendAsync(request);
        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        using (var responseStream = response.Content.ReadAsStream())
        using (var streamReader = new System.IO.StreamReader(responseStream))
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var serializer = JsonSerializer.Create();
            var actual = serializer.Deserialize<List<Car>>(jsonTextReader);
            if (actual == null)
            {
                Assert.False(true);
            }
            else
            {
                Assert.Equal(4, actual.Count);
                Assert.Equal("マツダ", actual[0].MakerName);
                Assert.Equal("CX-5", actual[0].ModelName);
                Assert.Equal("トヨタ", actual[1].MakerName);
                Assert.Equal("カローラツーリング", actual[1].ModelName);
                Assert.Equal("日産", actual[2].MakerName);
                Assert.Equal("ノート", actual[2].ModelName);
                Assert.Equal("BMW", actual[3].MakerName);
                Assert.Equal("3シリーズツーリング", actual[3].ModelName);
            }
        }
    }

    [Fact]
    public async void GetCarsReturnsCarListByMpcWltc()
    {
        // Arrange
        await prepareTestData();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars?mpcWltcLower=259");
        var response = await _client.SendAsync(request);
        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        using (var responseStream = response.Content.ReadAsStream())
        using (var streamReader = new System.IO.StreamReader(responseStream))
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var serializer = JsonSerializer.Create();
            var actual = serializer.Deserialize<List<Car>>(jsonTextReader);
            if (actual == null)
            {
                Assert.False(true);
            }
            else
            {
                Assert.Single(actual);
                Assert.Equal("ホンダ", actual[0].MakerName);
                Assert.Equal("Honda e", actual[0].ModelName);
            }
        }
    }

    [Fact]
    public async void GetCarsReturnsCarListByEcrWltc()
    {
        // Arrange
        await prepareTestData();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars?ecrWltcLower=138");
        var response = await _client.SendAsync(request);
        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        using (var responseStream = response.Content.ReadAsStream())
        using (var streamReader = new System.IO.StreamReader(responseStream))
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var serializer = JsonSerializer.Create();
            var actual = serializer.Deserialize<List<Car>>(jsonTextReader);
            if (actual == null)
            {
                Assert.False(true);
            }
            else
            {
                Assert.Single(actual);
                Assert.Equal("ホンダ", actual[0].MakerName);
                Assert.Equal("Honda e", actual[0].ModelName);
            }
        }
    }

    [Fact]
    public async void GetCarsReturnsCarListByEcrJc08()
    {
        // Arrange
        await prepareTestData();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars?ecrJc08Lower=135");
        var response = await _client.SendAsync(request);
        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        using (var responseStream = response.Content.ReadAsStream())
        using (var streamReader = new System.IO.StreamReader(responseStream))
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var serializer = JsonSerializer.Create();
            var actual = serializer.Deserialize<List<Car>>(jsonTextReader);
            if (actual == null)
            {
                Assert.False(true);
            }
            else
            {
                Assert.Single(actual);
                Assert.Equal("ホンダ", actual[0].MakerName);
                Assert.Equal("Honda e", actual[0].ModelName);
            }
        }
    }

    [Fact]
    public async void GetCarsReturnsCarListByMpcJc08()
    {
        // Arrange
        await prepareTestData();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars?mpcJc08Lower=274");
        var response = await _client.SendAsync(request);
        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        using (var responseStream = response.Content.ReadAsStream())
        using (var streamReader = new System.IO.StreamReader(responseStream))
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var serializer = JsonSerializer.Create();
            var actual = serializer.Deserialize<List<Car>>(jsonTextReader);
            if (actual == null)
            {
                Assert.False(true);
            }
            else
            {
                Assert.Single(actual);
                Assert.Equal("ホンダ", actual[0].MakerName);
                Assert.Equal("Honda e", actual[0].ModelName);
            }
        }
    }

    [Fact]
    public async void GetCarsReturnsCarListByFuelType()
    {
        // Arrange
        await prepareTestData();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars?fuelType=PREMIUM");
        var response = await _client.SendAsync(request);
        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        using (var responseStream = response.Content.ReadAsStream())
        using (var streamReader = new System.IO.StreamReader(responseStream))
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var serializer = JsonSerializer.Create();
            var actual = serializer.Deserialize<List<Car>>(jsonTextReader);
            if (actual == null)
            {
                Assert.False(true);
            }
            else
            {
                Assert.Single(actual);
                Assert.Equal("ホンダ", actual[0].MakerName);
                Assert.Equal("NSX", actual[0].ModelName);
            }
        }
    }

    #endregion

    #region GetCarのテスト
    [Fact]
    public async void GetCarReturnsValidInstance()
    {
        // Arrange
        await prepareTestData();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars/1");
        var response = await _client.SendAsync(request);
        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        using (var responseStream = response.Content.ReadAsStream())
        using (var streamReader = new System.IO.StreamReader(responseStream))
        using (var jsonTextReader = new JsonTextReader(streamReader))
        {
            var serializer = JsonSerializer.Create();
            var actual = serializer.Deserialize<Car>(jsonTextReader);
            if (actual == null)
            {
                Assert.False(true);
            }
            else
            {
                Assert.Equal("マツダ", actual.MakerName);
            }
        }
    }

    [Fact]
    public async void GetCarReturnsNotFound()
    {
        // Arrange
        await prepareTestData();
        // Act
        var request = new HttpRequestMessage(HttpMethod.Get, "/api/v1/cars/999");
        var response = await _client.SendAsync(request);
        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    #endregion
}
