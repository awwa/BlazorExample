using System;
using System.Linq;
using HogeBlazor.Client.Models;
// using HogeBlazor.Client.Helpers;

namespace HogeBlazor.Client.Test.Features;

public class ModelHelperTests : TestContext
{
    [Fact]
    public void HasValidPropertyValueReturnsFalse()
    {
        // Arrang & Act
        var motor = new Motor();
        var actual = Helpers.ModelHelper.HasValidPropertyValue(motor);
        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void HasValidPropertyValueReturnsTrue()
    {
        // Arrang & Act
        var motor = new Motor()
        {
            Code = "1234",
        };
        var actual = Helpers.ModelHelper.HasValidPropertyValue(motor);
        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void HasValidPropertyValueReturnsFalseIfNull()
    {
        // Arrang & Act
        var actual = Helpers.ModelHelper.HasValidPropertyValue(null);
        // Assert
        Assert.False(actual);
    }
}
