using HogeBlazor.Server.Controllers;
using HogeBlazor.Shared.Models;
using HogeBlazor.Server.Helpers;
using Xunit;
using System.Net;
using System.Net.Http;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;

namespace HogeBlazor.Server.Test.Controllers;

public class UsersControllerTests
{
    private readonly HttpClient _client;

    // https://docs.microsoft.com/ja-jp/aspnet/core/test/integration-tests?view=aspnetcore-6.0
    public UsersControllerTests()
    {
        var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.UseSetting("https_port", "5000");
            });
        _client = application.CreateClient();

        var options = new DbContextOptions<HogeBlazorDbContext>();
        var _context = new HogeBlazorDbContext(options);
    }

    [Fact]
    public async void Test2()
    {
        HttpResponseMessage response = await _client.GetAsync("/api/v1/Users");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        Debug.WriteLine(responseBody);
        List<User> users = JsonSerializer.Deserialize<List<User>>(responseBody);
        Assert.Equal(1, users.Count);
    }
    [Fact]
    public async void Test3()
    {
        var data = new List<User>
        {
            new User(id: 1, name: "ほげ太郎", email: "admin@example.com", User.RoleType.Admin)
        }.AsQueryable();

        var mockSet = new Mock<DbSet<User>>();
        mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<HogeBlazorDbContext>();
        mockContext.Setup(m => m.Users).Returns(mockSet.Object);

        var service = new UsersController(mockContext.Object);
        List<User> users = (List<User>)service.Get();

        // HttpResponseMessage response = await _client.GetAsync("/api/v1/Users");
        // response.EnsureSuccessStatusCode();
        // Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        // string responseBody = await response.Content.ReadAsStringAsync();
        // Debug.WriteLine(responseBody);
        // List<User> users = JsonSerializer.Deserialize<List<User>>(responseBody);
        Assert.Equal(1, users.Count);
    }
}