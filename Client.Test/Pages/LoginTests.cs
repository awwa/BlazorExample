using HogeBlazor.Client.Pages;

namespace HogeBlazor.Client.Test.Pages;

public class LoginTests : TestContext
{
    [Fact]
    public void Hoge()
    {
        // Arrange
        var cut = RenderComponent<Login>();

        // Assert that content of the paragraph shows counter at zero
        cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 0</p>");
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
