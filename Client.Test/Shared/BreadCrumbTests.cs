// using HogeBlazor.Client.Helpers;
using HogeBlazor.Client.Repositories;
using HogeBlazor.Client.Shared;
using System.Threading.Tasks;
using Moq;
using System;
using HogeBlazor.Shared.Models.Dto;

namespace HogeBlazor.Client.Test.Pages;

public class BreadCrumnbTests : BaseTestContext
{
    [Fact]
    public async Task BuildItemsAsyncReturnsSingleList0()
    {
        // Arrange
        var mock = new Mock<ICarHttpRepository>();
        var cut = RenderComponent<BreadCrumb>(parameters => parameters.Add(p => p.CarRepo, mock.Object));
        // Act
        var actual = await cut.Instance.BuildItemsAsync("http://localhost");
        // Assert
        Assert.Single(actual);
        Assert.Equal("/", actual[0].Path);
        Assert.Equal("ホーム", actual[0].Text);
    }

    [Fact]
    public async Task BuildItemsAsyncReturnsSingleList1()
    {
        // Arrange
        var cut = RenderComponent<BreadCrumb>();
        // Act
        var actual = await cut.Instance.BuildItemsAsync("http://localhost/");
        // Assert
        Assert.Single(actual);
        Assert.Equal("/", actual[0].Path);
        Assert.Equal("ホーム", actual[0].Text);
    }

    [Fact]
    public async Task BuildItemsAsyncReturnsDoubleList0()
    {
        // Arrange
        var cut = RenderComponent<BreadCrumb>();
        // Act
        var actual = await cut.Instance.BuildItemsAsync("http://localhost/cars");
        // Assert
        Assert.Equal(2, actual.Count);
        Assert.Equal("/", actual[0].Path);
        Assert.Equal("ホーム", actual[0].Text);
        Assert.Equal("", actual[1].Path);
        Assert.Equal("クルマ一覧", actual[1].Text);
    }

    [Fact]
    public async Task BuildItemsAsyncReturnsDoubleList1()
    {
        // Arrange
        var cut = RenderComponent<BreadCrumb>();
        // Act
        var actual = await cut.Instance.BuildItemsAsync("http://localhost/cars/");
        // // Assert
        Assert.Equal(2, actual.Count);
        Assert.Equal("/", actual[0].Path);
        Assert.Equal("ホーム", actual[0].Text);
        Assert.Equal("", actual[1].Path);
        Assert.Equal("クルマ一覧", actual[1].Text);
    }

    [Fact]
    public async Task BuildItemsAsyncReturnsTripleList0()
    {
        // Arrange
        var mock = new Mock<ICarHttpRepository>();
        mock.Setup(m => m.GetCarAsync("car_1")).ReturnsAsync(new CarDto("car_1") { ModelName = "CX-5" });
        Console.WriteLine("3");
        var cut = RenderComponent<BreadCrumb>(parameters => parameters.Add(p => p.CarRepo, mock.Object));
        Console.WriteLine("4");
        // Act
        var actual = await cut.Instance.BuildItemsAsync("http://localhost/cars/car_1");
        // Assert
        Assert.Equal(3, actual.Count);
        Assert.Equal("/", actual[0].Path);
        Assert.Equal("ホーム", actual[0].Text);
        Assert.Equal("/cars", actual[1].Path);
        Assert.Equal("クルマ一覧", actual[1].Text);
        Assert.Equal("", actual[2].Path);
        Assert.Equal("CX-5", actual[2].Text);
    }
}
