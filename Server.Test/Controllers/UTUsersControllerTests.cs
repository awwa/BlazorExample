using HogeBlazor.Server.Controllers;
using HogeBlazor.Shared.Models;
using HogeBlazor.Server.Helpers;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Moq;
using Microsoft.AspNetCore.Mvc;
using static HogeBlazor.Server.Controllers.UsersController;
using Microsoft.Extensions.Logging;

namespace HogeBlazor.Server.Test.Controllers;

public class UTUsersControllerTests
{
    // TODO ToListAsync()のモック化ができなかったためテストを省いている
    // 理解できていない参考情報：https://entityframeworkcore.com/knowledge-base/47965574/unit-testing-with-moq-sometimes-fails-on-tolistasync--
    // [Fact]
    // public void AllReturnsUserList()
    // {
    //     // Arrange
    //     var data = new List<User>
    //     {
    //         new User(id: 1, name: "ほげ太郎", email: "admin@example.com", User.RoleType.Admin)
    //     };
    //     var mockDbSet = new Mock<DbSet<User>>();
    //     mockDbSet.Setup(m => m.ToList<User>()).Returns(data);
    //     var mockContext = new Mock<HogeBlazorDbContext>();
    //     mockContext.Setup(m => m.Users).Returns(mockDbSet.Object);
    //     var controller = new UsersController(mockContext.Object);
    //     // Act
    //     ActionResult<List<UserDTO>> result = controller.All();
    //     // Assert
    //     var actionResult = Assert.IsType<ActionResult<List<UserDTO>>>(result);
    //     var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
    //     var list = Assert.IsType<List<UserDTO>>(okResult.Value);
    //     Assert.Equal(1, list.Count);
    // }

    // ASP.NET Core でコントローラーのロジックの単体テストを行う
    // https://docs.microsoft.com/ja-jp/aspnet/core/mvc/controllers/testing?view=aspnetcore-6.0
    [Fact]
    public async void GetByIdReturnsDTOObjectIfItExists()
    {
        // Arrange
        var data = new User(id: 1, name: "ほげ太郎", email: "admin@example.com", User.RoleType.Admin);
        var mockDbSet = new Mock<DbSet<User>>();
        mockDbSet.Setup(m => m.FindAsync(data.Id)).ReturnsAsync(data);
        var mockContext = new Mock<HogeBlazorDbContext>();
        mockContext.Setup(m => m.Users).Returns(mockDbSet.Object);
        var mockLogger = new Mock<ILogger<UsersController>>();
        var controller = new UsersController(mockContext.Object, mockLogger.Object);
        // Act
        ActionResult<UserDTO> result = await controller.GetById(1);
        // Assert
        var actionResult = Assert.IsType<ActionResult<UserDTO>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var user = Assert.IsType<UserDTO>(okResult.Value);
        Assert.Equal(1, user.Id);
    }

    [Fact]
    public async void GetByIdReturnsNotFoundIfNoExists()
    {
        // Arrange
        var data = new User(id: 1, name: "ほげ太郎", email: "admin@example.com", User.RoleType.Admin);
        var mockContext = new Mock<HogeBlazorDbContext>();
        var mockDbSet = new Mock<DbSet<User>>();
        mockDbSet.Setup(m => m.FindAsync(data.Id)).ReturnsAsync(data);
        mockContext.Setup(m => m.Users).Returns(mockDbSet.Object);
        var mockLogger = new Mock<ILogger<UsersController>>();
        var controller = new UsersController(mockContext.Object, mockLogger.Object);
        // Act
        ActionResult<UserDTO> result = await controller.GetById(2);
        // Assert
        var actionResult = Assert.IsType<ActionResult<UserDTO>>(result);
        var ngResult = Assert.IsType<NotFoundResult>(actionResult.Result);
        Assert.Equal(404, ngResult.StatusCode);
    }



}