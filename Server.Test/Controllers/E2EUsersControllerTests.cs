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
using Microsoft.AspNetCore.Mvc;
using static HogeBlazor.Server.Controllers.UsersController;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace HogeBlazor.Server.Test.Controllers;

public class E2EUsersControllerTests
{
    private readonly HttpClient _client;

    // ASP.NET Core での統合テスト
    // https://docs.microsoft.com/ja-jp/aspnet/core/test/integration-tests?view=aspnetcore-6.0
    public E2EUsersControllerTests()
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

    // [Fact]
    // public async void AllReturnsUserList()
    // {
    //     HttpResponseMessage response = await _client.GetAsync("/api/v1/users");
    //     response.EnsureSuccessStatusCode();
    //     Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    //     string responseBody = await response.Content.ReadAsStringAsync();
    //     Debug.WriteLine(responseBody);
    //     List<User> users = JsonSerializer.Deserialize<List<User>>(responseBody);
    //     Assert.Equal(1, users.Count);
    // }

    [Fact]
    public async void GetByQueryReturnsUserList()
    {
        HttpResponseMessage response = await _client.GetAsync("/api/v1/users/?name=管理者&email=admin@hogeblazor&role=0");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        var users = JsonSerializer.Deserialize<List<User>>(responseBody);
        if (users != null)
        {
            Assert.Equal(1, users.Count);
        }
        else
        {
            Assert.False(users != null);
        }
    }

    [Fact]
    public async void GetByQueryReturnsDTOObjectListIfItExists()
    {

    }

    [Fact]
    public async void GetByQueryReturnsEmptyListIfNoExists()
    {
        HttpResponseMessage response = await _client.GetAsync("/api/v1/users/?name=存在しない");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        var users = JsonSerializer.Deserialize<List<User>>(responseBody);
        if (users != null)
        {
            Assert.Equal(0, users.Count);
        }
        else
        {
            Assert.False(users != null);
        }
    }

    [Fact]
    public async void GetByQueryReturnsDTOObjectListForAll()
    {
        HttpResponseMessage response = await _client.GetAsync("/api/v1/users/");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        var users = JsonSerializer.Deserialize<List<User>>(responseBody);
        if (users != null)
        {
            Assert.Equal(3, users.Count);
        }
        else
        {
            Assert.False(users != null);
        }
    }

    [Fact]
    public async void GetByQueryReturnsDTOObjectListByName()
    {
        HttpResponseMessage response = await _client.GetAsync("/api/v1/users/?name=管理者");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        var users = JsonSerializer.Deserialize<List<User>>(responseBody);
        if (users != null)
        {
            Assert.Equal(1, users.Count);
        }
        else
        {
            Assert.False(users != null);
        }
    }

    [Fact]
    public async void GetByQueryReturnsDTOObjectListByEmail()
    {
        HttpResponseMessage response = await _client.GetAsync("/api/v1/users/?email=user@hogeblazor");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        var users = JsonSerializer.Deserialize<List<User>>(responseBody);
        if (users != null)
        {
            Assert.Equal(1, users.Count);
        }
        else
        {
            Assert.False(users != null);
        }
    }

    [Fact]
    public async void GetByQueryReturnsDTOObjectListByRole()
    {
        HttpResponseMessage response = await _client.GetAsync("/api/v1/users/?role=2");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        var users = JsonSerializer.Deserialize<List<User>>(responseBody);
        if (users != null)
        {
            Assert.Equal(1, users.Count);
        }
        else
        {
            Assert.False(users != null);
        }
    }

    [Fact]
    public async void GetByQueryReturnsDTOObjectListByNameAndEmail()
    {
        HttpResponseMessage response = await _client.GetAsync("/api/v1/users/?name=管理者&email=admin@hogeblazor");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        var users = JsonSerializer.Deserialize<List<User>>(responseBody);
        if (users != null)
        {
            Assert.Equal(1, users.Count);
        }
        else
        {
            Assert.False(users != null);
        }
    }

    [Fact]
    public async void GetByQueryReturnsDTOObjectListByEmailAndRole()
    {
        HttpResponseMessage response = await _client.GetAsync("/api/v1/users/?email=admin@hogeblazor&role=0");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        var users = JsonSerializer.Deserialize<List<User>>(responseBody);
        if (users != null)
        {
            Assert.Equal(1, users.Count);
        }
        else
        {
            Assert.False(users != null);
        }
    }

    [Fact]
    public async void GetByQueryReturnsDTOObjectListByNameAndRole()
    {
        HttpResponseMessage response = await _client.GetAsync("/api/v1/users/?name=管理者&role=0");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        var users = JsonSerializer.Deserialize<List<User>>(responseBody);
        if (users != null)
        {
            Assert.Equal(1, users.Count);
        }
        else
        {
            Assert.False(users != null);
        }
    }
}