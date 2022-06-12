
using Xunit;
using HogeBlazor.Server.Helpers;
using System.Collections.Generic;
using HogeBlazor.Shared.Models.Db;
using System;

namespace HogeBlazor.Server.Test.Helpers;

public class QueryHelperTests
{
    [Fact]
    public void GetOrExpressionReturnsValidValue()
    {
        // Arrange
        var searchValues = new List<string> { "マツダ", "トヨタ" };
        // Act
        var actual = QueryHelper.GetOrExpression<Car>("MakerName", searchValues);
        // Assert
        Assert.Equal("(x.MakerName.Equals(\"マツダ\") OrElse x.MakerName.Equals(\"トヨタ\"))", actual.Body.ToString());
    }

    [Fact]
    public void GetOrExpressionThrowsExceptionWithEmptySearchValues()
    {
        // Arrange
        var searchValues = new List<string>();
        // Act
        // Assert
        var actual = Assert.Throws<ArgumentException>(() =>
        {
            QueryHelper.GetOrExpression<Car>("MakerName", searchValues);
        });
        Assert.Equal("searchValuesには1以上の要素を指定する必要があります", actual.Message);
    }

    [Fact]
    public void GetOrExpressionThrowsExceptionWithNoExistProerty()
    {
        // Arrange
        var searchValues = new List<string> { "マツダ", "トヨタ" };
        // Act
        // Assert
        var actual = Assert.Throws<ArgumentException>(() =>
        {
            QueryHelper.GetOrExpression<Car>("存在しないプロパティ", searchValues);
        });
        Assert.Equal("Instance property '存在しないプロパティ' is not defined for type 'HogeBlazor.Shared.Models.Db.Car' (Parameter 'propertyName')", actual.Message);
    }
}