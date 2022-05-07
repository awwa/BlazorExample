using HogeBlazor.Client.Helpers;
using HogeBlazor.Client.Pages;
using HogeBlazor.Client.Repositories;
using HogeBlazor.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace HogeBlazor.Client.Test.Pages;

public class LoginTests : BaseTestContext
{
    [Fact]
    public void LoginShowsErrorIfFormIsEmpty()
    {
        // Arrange
        var cut = RenderComponent<Login>();
        // Assert
        Assert.False(cut.Instance.ShowAuthError);
        Assert.Throws<ElementNotFoundException>(() =>
        {
            cut.Find("#error");
            cut.Find("#error-email");
            cut.Find("#error-password");
        });
        cut.Find($"button[type=\"submit\"]").Click();
        Assert.Equal("The Email field is required.", cut.Find($"#error-email").TextContent);
        Assert.Equal("The Password field is required.", cut.Find($"#error-password").TextContent);
    }

    // [Fact]
    // public void ClickingButtonIncrementsCounter()
    // {
    //     // Arrange
    //     var cut = RenderComponent<Counter>();

    //     // Act - click button to increment counter
    //     cut.Find("button").Click();

    //     // Assert that the counter was incremented
    //     cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 1</p>");
    // }
}
