
// using Xunit;
// using HogeBlazor.Server.Helpers;
// using HogeBlazor.Shared.Models;

// namespace HogeBlazor.Server.Test.Helpers;

// public class EnumHelperTests
// {
//     #region TryParseのテスト
//     [Fact]
//     public void TryParseTransformValidValue()
//     {
//         // Arrange
//         User.RoleType role;
//         // Act
//         var actual = EnumHelper.TryParse("Admin", out role);
//         // Assert
//         Assert.True(actual);
//         Assert.Equal(User.RoleType.Admin, role);
//     }

//     [Fact]
//     public void TryParseReturnsFalseIfValueIsInvalid()
//     {
//         // Arrange
//         User.RoleType role;
//         // Act
//         var actual = EnumHelper.TryParse("Hoge", out role);
//         // Assert
//         Assert.False(actual);
//     }
//     #endregion
// }