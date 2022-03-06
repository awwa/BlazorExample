using Xunit;
using HogeBlazor.Client.Models;

namespace HogeBlazor.Client.Test.Models;

public class HogeTests : TestContext
{
    [Fact]
	public void ValidateReturnsTrue()
	{
        var hoge = new Hoge();
        Assert.True(hoge.Validate("fuga"));
	}

}