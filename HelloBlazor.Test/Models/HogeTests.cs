using Xunit;
using HelloBlazor.Models;

namespace HelloBlazor.Test.Models;

public class HogeTests : TestContext
{
    [Fact]
	public void ValidateReturnsTrue()
	{
        var hoge = new Hoge();
        Assert.True(hoge.Validate("fuga"));
	}

}