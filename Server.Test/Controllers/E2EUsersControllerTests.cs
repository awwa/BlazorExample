using HogeBlazor.Shared.Models;
using HogeBlazor.Server.Helpers;
using Xunit;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System;
using static HogeBlazor.Server.Controllers.UsersController;

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

    [Fact]
    public async void GetUserByQueryReturnsUserList()
    {
        HttpResponseMessage response = await _client.GetAsync("/api/v1/users/?name=管理者&email=admin@hogeblazor&role=0");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        var users = JsonSerializer.Deserialize<List<UserDTO>>(responseBody);
        if (users != null)
        {
            Assert.Single(users);
        }
        else
        {
            Assert.False(users != null);
        }
    }

    [Fact]
    public async void GetUserByQueryReturnsEmptyListIfNoExists()
    {
        HttpResponseMessage response = await _client.GetAsync("/api/v1/users/?name=存在しない");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        var users = JsonSerializer.Deserialize<List<UserDTO>>(responseBody);
        if (users != null)
        {
            Assert.Empty(users);
        }
        else
        {
            Assert.False(users != null);
        }
    }

    [Fact]
    public async void GetUserByQueryReturnsDTOObjectListForAll()
    {
        HttpResponseMessage response = await _client.GetAsync("/api/v1/users/");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        var users = JsonSerializer.Deserialize<List<UserDTO>>(responseBody);
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
    public async void GetUserByQueryReturnsDTOObjectListByName()
    {
        HttpResponseMessage response = await _client.GetAsync("/api/v1/users/?name=管理者");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        var users = JsonSerializer.Deserialize<List<UserDTO>>(responseBody);
        if (users != null)
        {
            Assert.Single(users);
        }
        else
        {
            Assert.False(users != null);
        }
    }

    [Fact]
    public async void GetUserByQueryReturnsDTOObjectListByEmail()
    {
        HttpResponseMessage response = await _client.GetAsync("/api/v1/users/?email=user@hogeblazor");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        var users = JsonSerializer.Deserialize<List<UserDTO>>(responseBody);
        if (users != null)
        {
            Assert.Single(users);
        }
        else
        {
            Assert.False(users != null);
        }
    }

    [Fact]
    public async void GetUserByQueryReturnsDTOObjectListByRole()
    {
        HttpResponseMessage response = await _client.GetAsync("/api/v1/users/?role=2");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        var users = JsonSerializer.Deserialize<List<UserDTO>>(responseBody);
        if (users != null)
        {
            Assert.Single(users);
        }
        else
        {
            Assert.False(users != null);
        }
    }

    [Fact]
    public async void GetUserByQueryReturnsDTOObjectListByNameAndEmail()
    {
        HttpResponseMessage response = await _client.GetAsync("/api/v1/users/?name=管理者&email=admin@hogeblazor");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        var users = JsonSerializer.Deserialize<List<UserDTO>>(responseBody);
        if (users != null)
        {
            Assert.Single(users);
        }
        else
        {
            Assert.False(users != null);
        }
    }

    [Fact]
    public async void GetUserByQueryReturnsDTOObjectListByEmailAndRole()
    {
        HttpResponseMessage response = await _client.GetAsync("/api/v1/users/?email=admin@hogeblazor&role=0");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        var users = JsonSerializer.Deserialize<List<UserDTO>>(responseBody);
        if (users != null)
        {
            Assert.Single(users);
        }
        else
        {
            Assert.False(users != null);
        }
    }

    [Fact]
    public async void GetUserByQueryReturnsDTOObjectListByNameAndRole()
    {
        HttpResponseMessage response = await _client.GetAsync("/api/v1/users/?name=管理者&role=0");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseBody);
        var users = JsonSerializer.Deserialize<List<UserDTO>>(responseBody);
        if (users != null)
        {
            Assert.Single(users);
        }
        else
        {
            Assert.False(users != null);
        }
    }

    // Userモデルのアノテーションによる制限がAPIアクセス時にかかっていることは確認済み
    // 細かいテストはモデルのUTにおまかせする
    // [Fact]
    // public async void HogeTestE2E()
    // {
    //     var param = new Dictionary<string, object>()
    //     {
    //         ["name"] = "ほげ 太郎",
    //         ["email"] = "add@hogeblazor",
    //         ["plainPassword"] = "plain_password",
    //         ["role"] = User.RoleType.User,
    //     };
    //     var jsonString = System.Text.Json.JsonSerializer.Serialize(param);
    //     var content = new StringContent(jsonString, Encoding.UTF8, @"application/json");

    //     HttpResponseMessage response = await _client.PostAsync("/api/v1/users/", content);
    //     response.EnsureSuccessStatusCode();
    //     Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    //     string responseBody = await response.Content.ReadAsStringAsync();
    //     Console.WriteLine(responseBody);
    // }

    // [Fact]
    // public async void PostUser()
    // {
    //     var param = new Dictionary<string, object>()
    //     {
    //         ["name"] = "追加ユーザー",
    //         ["email"] = "add@hogeblazor",
    //         ["password"] = "plain_password",
    //         ["role"] = User.RoleType.User,
    //     };
    //     var jsonString = System.Text.Json.JsonSerializer.Serialize(param);
    //     var content = new StringContent(jsonString, Encoding.UTF8, @"application/json");
    //     HttpResponseMessage response = await _client.PostAsync("/api/v1/users", content);
    //     response.EnsureSuccessStatusCode();
    //     Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    //     string responseBody = await response.Content.ReadAsStringAsync();
    //     Assert.NotNull(responseBody);
    //     var user = JsonSerializer.Deserialize<User>(responseBody);
    //     Assert.NotNull(user);
    //     Assert.Equal("追加ユーザー", user.Name);
    // }

    // [Fact]
    // public void DeleteUser()
    // {
    //     //DbContextのオプションを作成
    //     var options = new DbContextOptionsBuilder<HogeBlazorDbContext>()
    //         .UseInMemoryDatabase(databaseName: "UnitTestDB")
    //         .Options;

    //     //DbContextをインスタンス化
    //     var context = new HogeBlazorDbContext(options);
    //     var users = context.Users.ToList<User>();
    //     foreach (var user in users)
    //     {
    //         context.Remove(user);
    //     }
    //     context.SaveChanges();
    //     Assert.Equal(0, context.Users.ToList<User>().Count);

    // }
}