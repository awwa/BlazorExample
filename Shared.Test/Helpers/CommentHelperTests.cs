using System;
using System.Collections.Generic;
using HogeBlazor.Shared.Models.Db;
using Xunit;
using System.Text.Json;

namespace HogeBlazor.Shared.Test.Helpers;

public class CommentHelperTests
{
    [Fact]
    public void GetCommentAttributeReturnsValidComment()
    {
        // Arrange
        // Act
        var actual = CommentHelper.GetCommentAttributeOnProperty<Car>("ModelName");
        // Assert
        Assert.Equal("モデル名", actual);
    }

    [Fact]
    public void GetCommentAttributeReturnsValidValueForOwnedClassProperty()
    {
        // Arrange
        // Act
        var actual = CommentHelper.GetCommentAttributeOnProperty<Body>("Type");
        // Assert
        Assert.Equal("ボディタイプ", actual);
    }

    [Fact]
    public void GetCommentAttributeReturnsEmptyValue()
    {
        // Arrange
        // Act
        // Assert
        Assert.Throws<NotImplementedException>(() =>
        {
            CommentHelper.GetCommentAttributeOnProperty<Car>("存在しないプロパティ");
        });
    }
}