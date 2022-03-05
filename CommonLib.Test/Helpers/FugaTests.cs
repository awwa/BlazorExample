using Xunit;
using CommonLib.Helpers;

namespace CommonLib.Test.Helpers;

public class FugaTests
{
    [Fact]
	public void HellowReturnsWorld()
	{
        Assert.Equal("World", Fuga.Hello());
	}

}