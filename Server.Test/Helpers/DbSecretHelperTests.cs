
using Xunit;
using HogeBlazor.Server.Helpers;
using System.Collections.Generic;
using HogeBlazor.Shared.Models.Db;
using System;
using System.Threading.Tasks;

namespace HogeBlazor.Server.Test.Helpers;

public class DbSecretHelperTests
{
    [Fact]
    public async Task GetSecretReturnsValidValue()
    {
        // Arrange
        // Act
        var actual = await DbSecretHelper.GetSecret();
        // Assert
        Assert.NotEmpty(actual);
    }
}