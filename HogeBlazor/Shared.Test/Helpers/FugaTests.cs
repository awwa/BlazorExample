using Xunit;
using Shared.Helpers;

namespace Shared.Test.Helpers;

public class FugaTests
{
    [Fact]
	public void HellowReturnsWorld()
	{
        Assert.Equal("World", Fuga.Hello());
	}

}