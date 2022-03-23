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
using Microsoft.Data.Sqlite;

namespace HogeBlazor.Server.Test.Controllers;

public class UTUsersControllerTests
{
    private HogeBlazorDbContext _context;
    private UsersController _controller;
    public UTUsersControllerTests()
    {
        // DbContextはMoqで置き換えれない。UseInMemoryを使う(C# EFCore)
        // https://demi-urge.com/useinmemory/
        // DbContextとControllerをインスタンス化
        var options = new DbContextOptionsBuilder<HogeBlazorDbContext>()
            // .use
            .UseInMemoryDatabase(databaseName: "UnitTestDB")
            .Options;
        _context = new HogeBlazorDbContext(options);
        var mockLogger = new Mock<ILogger<UsersController>>();
        _controller = new UsersController(_context, mockLogger.Object);
    }

    /// <summary>
    /// テーブルクリア処理
    /// </summary>
    /// <returns></returns>
    private async Task ClearTable()
    {
        // .IgnoreQueryFilters() で論理削除を無視して全データを取得
        var users = await _context.Users.IgnoreQueryFilters().ToListAsync<User>();
        foreach (var user in users)
        {
            _context.Users.Remove(user);
        }
        await _context.SaveChangesAsync();
    }

    private async Task AddBasicData()
    {
        _context.Users.Add(new User(id: 1, name: "管理者", email: "admin@example.com", User.RoleType.Admin));
        _context.Users.Add(new User(id: 2, name: "削除済みユーザー", email: "deleted@hogeblazor", role: User.RoleType.Admin) { IsDel = true });
        _context.Users.Add(new User(id: 3, name: "一般ユーザー", email: "user@hogeblazor", role: User.RoleType.User));
        _context.Users.Add(new User(id: 4, name: "ゲストユーザー", email: "guest@hogeblazor", role: User.RoleType.Guest));
        await _context.SaveChangesAsync();
    }

    #region GetUserByQuery()テスト
    // ASP.NET Core でコントローラーのロジックの単体テストを行う
    // https://docs.microsoft.com/ja-jp/aspnet/core/mvc/controllers/testing?view=aspnetcore-6.0
    [Fact]
    public async void GetUserByQueryReturnsDTOListIfItExistsByName()
    {
        // Arrange
        await ClearTable();
        await AddBasicData();
        // Act
        ActionResult<List<UserDTO>> result = await _controller.GetUserByQuery(name: "管理者", email: null, role: null);
        // Assert
        var actionResult = Assert.IsType<ActionResult<List<UserDTO>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var users = Assert.IsType<List<UserDTO>>(okResult.Value);
        Assert.Equal(1, users.Count);
        Assert.Equal("管理者", users[0].Name);
    }

    [Fact]
    public async void GetUserByQueryReturnsDTOListIfItExistsByEmail()
    {
        // Arrange
        await ClearTable();
        await AddBasicData();
        // Act
        ActionResult<List<UserDTO>> result = await _controller.GetUserByQuery(name: null, email: "user@hogeblazor", role: null);
        // Assert
        var actionResult = Assert.IsType<ActionResult<List<UserDTO>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var users = Assert.IsType<List<UserDTO>>(okResult.Value);
        Assert.Equal(1, users.Count);
        Assert.Equal("一般ユーザー", users[0].Name);
    }

    [Fact]
    public async void GetUserByQueryReturnsDTOListIfItExistsByRole()
    {
        // Arrange
        await ClearTable();
        await AddBasicData();
        // Act
        ActionResult<List<UserDTO>> result = await _controller.GetUserByQuery(name: null, email: null, role: User.RoleType.Admin);
        // Assert
        var actionResult = Assert.IsType<ActionResult<List<UserDTO>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var users = Assert.IsType<List<UserDTO>>(okResult.Value);
        Assert.Equal(1, users.Count);
        Assert.Equal("管理者", users[0].Name);
    }

    [Fact]
    public async void GetUserByQueryReturnsEmptyListIfItNotExists()
    {
        // Arrange
        await ClearTable();
        await AddBasicData();
        // Act
        ActionResult<List<UserDTO>> result = await _controller.GetUserByQuery(name: "存在しないユーザー", email: null, role: null);
        // Assert
        var actionResult = Assert.IsType<ActionResult<List<UserDTO>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var users = Assert.IsType<List<UserDTO>>(okResult.Value);
        Assert.Equal(0, users.Count);
    }

    [Fact]
    public async void GetUserByQueryNotReturnsDeletedObject()
    {
        // Arrange
        await ClearTable();
        await AddBasicData();
        // Act
        ActionResult<List<UserDTO>> result = await _controller.GetUserByQuery(name: "削除済みユーザー", email: null, role: null);
        // Assert
        var actionResult = Assert.IsType<ActionResult<List<UserDTO>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var users = Assert.IsType<List<UserDTO>>(okResult.Value);
        Assert.Equal(0, users.Count);
    }
    #endregion

    #region GetUserById()テスト
    [Fact]
    public async void GetUserByIdReturnsDTOObjectIfItExists()
    {
        // Arrange
        await ClearTable();
        await AddBasicData();
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
        await ClearTable();
        await AddBasicData();
        // Act
        ActionResult<UserDTO> result = await _controller.GetUserById(5);
        // Assert
        var actionResult = Assert.IsType<ActionResult<UserDTO>>(result);
        var ngResult = Assert.IsType<NotFoundResult>(actionResult.Result);
        Assert.Equal(404, ngResult.StatusCode);
    }

    [Fact]
    public async void GetUserByIdReturnsDTOObjectIfItIsDeleted()
    {
        // Arrange
        await ClearTable();
        await AddBasicData();
        // Act
        ActionResult<UserDTO> result = await _controller.GetUserById(2);
        // Assert
        var actionResult = Assert.IsType<ActionResult<UserDTO>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        Assert.Equal(200, okResult.StatusCode);
        var user = Assert.IsType<UserDTO>(okResult.Value);
        Assert.Equal("削除済みユーザー", user.Name);
        Assert.Equal(true, user.IsDel);

    }
    #endregion

    #region PostUser()テスト
    [Fact]
    public async void PostUserSuccessForEmptyTable()
    {
        // Arrange
        await ClearTable();
        // Act
        var data = new User(id: 1, name: "ほげ太郎", email: "admin@example.com", User.RoleType.Admin);
        ActionResult<UserDTO> result = await _controller.PostUser(data);
        // Assert
        var actionResult = Assert.IsType<ActionResult<UserDTO>>(result);
        var createdResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
        Assert.Equal(201, createdResult.StatusCode);
        var user = Assert.IsType<UserDTO>(createdResult.Value);
        Assert.Equal(1, user.Id);
    }

    [Fact]
    public async void PostUserFailsIfDuplicateKey()
    {
        // Arrange
        await ClearTable();
        // Act
        var data = new User(id: 1, name: "ほげ太郎", email: "admin@example.com", User.RoleType.Admin);
        await _controller.PostUser(data);
        ActionResult<UserDTO> result = await _controller.PostUser(data);    // 重複するデータをPOST
        // Assert
        var actionResult = Assert.IsType<ActionResult<UserDTO>>(result);
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        Assert.Equal(400, badRequestResult.StatusCode);
    }
    #endregion

    #region DeleteUser()テスト
    [Fact]
    public async void DeleteUserSuccess()
    {
        // Arrange
        await ClearTable();
        await AddBasicData();
        // Act
        ActionResult result = await _controller.DeleteUser(1);
        // Assert
        var noContentResult = Assert.IsType<NoContentResult>(result);
        Assert.Equal(204, noContentResult.StatusCode);
    }

    [Fact]
    public async void DeleteUserFailIfItNoExists()
    {
        // Arrange
        await ClearTable();
        await AddBasicData();
        // Act
        ActionResult result = await _controller.DeleteUser(5);
        // Assert
        var notFoundResult = Assert.IsType<NotFoundResult>(result);
        Assert.Equal(404, notFoundResult.StatusCode);
    }
    #endregion


}