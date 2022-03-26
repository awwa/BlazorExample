using HogeBlazor.Server.Controllers;
using HogeBlazor.Shared.Models;
using HogeBlazor.Server.Helpers;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Moq;
using Microsoft.AspNetCore.Mvc;
using static HogeBlazor.Server.Controllers.UsersController;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.Data.Sqlite;

namespace HogeBlazor.Server.Test.Controllers;

public class UTUsersControllerTests : IDisposable
{
    private HogeBlazorDbContext _context;
    private SqliteConnection _connection;
    private readonly DbContextOptions<HogeBlazorDbContext> _contextOptions;
    private UsersController _controller;

    #region テスト準備
    public UTUsersControllerTests()
    {
        // テストではSQLite インメモリを使う
        // https://docs.microsoft.com/ja-jp/ef/core/testing/testing-without-the-database#sqlite-in-memory
        // 実物のDBとはいくつか挙動が異なる点があるので要注意
        // DbContextとControllerをインスタンス化
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();
        _contextOptions = new DbContextOptionsBuilder<HogeBlazorDbContext>()
            .UseSqlite(_connection)
            .Options;
        _context = CreateContext();

        // DB構築
        if (_context.Database.EnsureCreated())
        {
        }

        var mockLogger = new Mock<ILogger<UsersController>>();
        _controller = new UsersController(_context, mockLogger.Object);
    }

    HogeBlazorDbContext CreateContext() => new HogeBlazorDbContext(_contextOptions);
    public void Dispose() => _connection.Dispose();

    /// <summary>
    /// テーブルクリア
    /// </summary>
    /// <returns></returns>
    private async Task ClearTable(HogeBlazorDbContext context)
    {
        // .IgnoreQueryFilters() で論理削除を無視して全データを取得して削除
        var users = await context.Users.IgnoreQueryFilters().ToListAsync<User>();
        foreach (var user in users)
        {
            context.Users.Remove(user);
        }
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// 初期データ投入
    /// </summary>
    /// <param name="context">DbContext</param>
    /// <returns></returns>
    private async Task AddBasicData(HogeBlazorDbContext context)
    {
        context.Users.AddRange(
            new User(name: "管理者", email: "admin@example.com", plainPassword: "password", role: User.RoleType.Admin) { Id = 1 },
            new User(name: "削除済みユーザー", email: "deleted@hogeblazor", plainPassword: "password", role: User.RoleType.Admin) { Id = 2, IsDel = true },
            new User(name: "一般ユーザー", email: "user@hogeblazor", plainPassword: "password", role: User.RoleType.User) { Id = 3 },
            new User(name: "ゲストユーザー", email: "guest@hogeblazor", plainPassword: "password", role: User.RoleType.Guest) { Id = 4 }
        );
        await context.SaveChangesAsync();
    }
    #endregion

    #region GetUserByQuery()テスト
    // ASP.NET Core でコントローラーのロジックの単体テストを行う
    // https://docs.microsoft.com/ja-jp/aspnet/core/mvc/controllers/testing?view=aspnetcore-6.0
    // コントローラのUTではモデルクラスのバリデーションは行われない
    // モデルクラスのバリデーションはモデルクラスのUT（Share.Test/Models/UserTest.csなど）で行ってください
    [Fact]
    public async void GetUserByQueryReturnsDTOListIfItExistsByName()
    {
        // Arrange
        await ClearTable(_context);
        await AddBasicData(_context);
        // Act
        ActionResult<List<UserDTO>> result = await _controller.GetUserByQuery(name: "管理者");
        // Assert
        var actionResult = Assert.IsType<ActionResult<List<UserDTO>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var users = Assert.IsType<List<UserDTO>>(okResult.Value);
        Assert.Single(users);
        Assert.Equal("管理者", users[0].Name);
    }

    [Fact]
    public async void GetUserByQueryReturnsDTOListIfItExistsByEmail()
    {
        // Arrange
        await ClearTable(_context);
        await AddBasicData(_context);
        // Act
        ActionResult<List<UserDTO>> result = await _controller.GetUserByQuery(email: "user@hogeblazor");
        // Assert
        var actionResult = Assert.IsType<ActionResult<List<UserDTO>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var users = Assert.IsType<List<UserDTO>>(okResult.Value);
        Assert.Single(users);
        Assert.Equal("一般ユーザー", users[0].Name);
    }

    [Fact]
    public async void GetUserByQueryReturnsDTOListIfItExistsByRole()
    {
        // Arrange
        await ClearTable(_context);
        await AddBasicData(_context);
        // Act
        ActionResult<List<UserDTO>> result = await _controller.GetUserByQuery(role: User.RoleType.Admin);
        // Assert
        var actionResult = Assert.IsType<ActionResult<List<UserDTO>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var users = Assert.IsType<List<UserDTO>>(okResult.Value);
        Assert.Single(users);
        Assert.Equal("管理者", users[0].Name);
    }

    [Fact]
    public async void GetUserByQueryReturnsEmptyListIfItNotExists()
    {
        // Arrange
        await ClearTable(_context);
        await AddBasicData(_context);
        // Act
        ActionResult<List<UserDTO>> result = await _controller.GetUserByQuery(name: "存在しないユーザー");
        // Assert
        var actionResult = Assert.IsType<ActionResult<List<UserDTO>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var users = Assert.IsType<List<UserDTO>>(okResult.Value);
        Assert.Empty(users);
    }

    [Fact]
    public async void GetUserByQueryNotReturnsDeletedObject()
    {
        // Arrange
        await ClearTable(_context);
        await AddBasicData(_context);
        // Act
        ActionResult<List<UserDTO>> result = await _controller.GetUserByQuery(name: "削除済みユーザー");
        // Assert
        var actionResult = Assert.IsType<ActionResult<List<UserDTO>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var users = Assert.IsType<List<UserDTO>>(okResult.Value);
        Assert.Empty(users);
    }

    [Fact]
    public async void GetUserByQueryReturnsAllDTOListIfNoParamSpecified()
    {
        // Arrange
        await ClearTable(_context);
        await AddBasicData(_context);
        // Act
        ActionResult<List<UserDTO>> result = await _controller.GetUserByQuery();
        // Assert
        var actionResult = Assert.IsType<ActionResult<List<UserDTO>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var users = Assert.IsType<List<UserDTO>>(okResult.Value);
        Assert.Equal(3, users.Count);
    }

    [Fact]
    public async void GetUserByQueryReturnsAllDTOListIfNullParamSpecified()
    {
        // Arrange
        await ClearTable(_context);
        await AddBasicData(_context);
        // Act
        ActionResult<List<UserDTO>> result = await _controller.GetUserByQuery(name: null, email: null, role: null);
        // Assert
        var actionResult = Assert.IsType<ActionResult<List<UserDTO>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var users = Assert.IsType<List<UserDTO>>(okResult.Value);
        Assert.Equal(3, users.Count);
        Console.WriteLine(users[0].CreatedAt);
    }
    #endregion

    #region GetUserById()テスト
    [Fact]
    public async void GetUserByIdReturnsDTOObjectIfItExists()
    {
        // Arrange
        await ClearTable(_context);
        await AddBasicData(_context);
        // Act
        ActionResult<UserDTO> result = await _controller.GetUserById(1);
        // Assert
        var actionResult = Assert.IsType<ActionResult<UserDTO>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var user = Assert.IsType<UserDTO>(okResult.Value);
        Assert.Equal(1, user.Id);
    }

    [Fact]
    public async void GetUserByIdReturnsNotFoundIfNoExists()
    {
        // Arrange
        await ClearTable(_context);
        await AddBasicData(_context);
        // Act
        ActionResult<UserDTO> result = await _controller.GetUserById(5);
        // Assert
        var actionResult = Assert.IsType<ActionResult<UserDTO>>(result);
        var ngResult = Assert.IsType<NotFoundResult>(actionResult.Result);
    }

    [Fact]
    public async void GetUserByIdReturnsDTOObjectIfItIsDeleted()
    {
        // Arrange
        await ClearTable(_context);
        await AddBasicData(_context);
        // Act
        ActionResult<UserDTO> result = await _controller.GetUserById(2);
        // Assert
        var actionResult = Assert.IsType<ActionResult<UserDTO>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var user = Assert.IsType<UserDTO>(okResult.Value);
        Assert.Equal("削除済みユーザー", user.Name);
        Assert.True(user.IsDel);
    }
    #endregion

    #region PostUser()テスト
    [Fact]
    public async void PostUserSuccessForEmptyTable()
    {
        // Arrange
        await ClearTable(_context);
        // Act
        var data = new User(name: "ほげ太郎", email: "admin@example.com", plainPassword: "password", role: User.RoleType.Admin) { };
        ActionResult<UserDTO> result = await _controller.PostUser(data);
        // Assert
        var actionResult = Assert.IsType<ActionResult<UserDTO>>(result);
        var createdResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
        var user = Assert.IsType<UserDTO>(createdResult.Value);
        Assert.Equal(5, user.Id);
        Assert.Equal("ほげ太郎", user.Name);
        Assert.Equal("admin@example.com", user.Email);
        Assert.Equal(User.RoleType.Admin, user.Role);
        var now = DateTime.UtcNow;
        Assert.InRange<int>((now - user.CreatedAt).Seconds, 0, 2);
        Assert.InRange<int>((now - user.UpdatedAt).Seconds, 0, 2);
        Assert.False(user.IsDel);
    }

    [Fact]
    public async void PostUserFailsIfDuplicateKey()
    {
        // Arrange
        await ClearTable(_context);
        // Act
        var data = new User(name: "ほげ太郎", email: "admin@example.com", plainPassword: "password", role: User.RoleType.Admin) { Id = 1 };
        await _controller.PostUser(data);
        ActionResult<UserDTO> result = await _controller.PostUser(data);    // 重複するデータをPOST
        // Assert
        var actionResult = Assert.IsType<ActionResult<UserDTO>>(result);
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
    }
    #endregion

    #region DeleteUser()テスト
    [Fact]
    public async void DeleteUserSuccess()
    {
        // Arrange
        await ClearTable(_context);
        await AddBasicData(_context);
        // Act
        ActionResult result = await _controller.DeleteUser(1);
        // Assert
        var noContentResult = Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async void DeleteUserFailIfItNoExists()
    {
        // Arrange
        await ClearTable(_context);
        await AddBasicData(_context);
        // Act
        ActionResult result = await _controller.DeleteUser(5);
        // Assert
        var notFoundResult = Assert.IsType<NotFoundResult>(result);
    }
    #endregion
    // [Fact]
    // public void TestHoge()
    // {
    //     ActionResult result = _controller.Hoge(null);
    //     var okResult = Assert.IsType<OkResult>(result);
    // }

}