
// using Xunit;
// using HogeBlazor.Server.Helpers;
// using System.Security.Claims;
// using HogeBlazor.Shared.Models;
// using System;

// namespace HogeBlazor.Server.Test.Helpers;

// public class ClaimsHelperTests
// {
//     #region ClaimsToUserのテスト
//     [Fact]
//     public void ClaimsToUserReturnsValidValue()
//     {
//         // Arrange
//         var claims = new[]
//         {
//             new Claim(ClaimTypes.Sid, 1.ToString()),
//             new Claim(ClaimTypes.Name, "あああ"),
//             new Claim(ClaimTypes.Email, "hoge@example.com"),
//             new Claim(ClaimTypes.Role, User.RoleType.Admin.ToString()),
//         };
//         var identity = new ClaimsIdentity(claims, "Test");
//         var principal = new ClaimsPrincipal(identity);
//         // Act
//         User user = ClaimsHelper.ClaimsToUser(principal);
//         // Assert
//         Assert.Equal(1, user.Id);
//         Assert.Equal("あああ", user.Name);
//         Assert.Equal("hoge@example.com", user.Email);
//         Assert.Equal(User.RoleType.Admin, user.Role);
//     }

//     [Fact]
//     public void ClaimsToUserThrowsExceptionIfValueIsInvalid()
//     {
//         // Arrange
//         var claims = new[]
//         {
//             new Claim(ClaimTypes.Sid, "あああ"),
//             new Claim(ClaimTypes.Name, "あああ"),
//             new Claim(ClaimTypes.Email, "hoge@example.com"),
//             new Claim(ClaimTypes.Role, "1"),
//         };
//         var identity = new ClaimsIdentity(claims, "Test");
//         var principal = new ClaimsPrincipal(identity);
//         // Act
//         // Assert
//         Assert.Throws<Exception>(() =>
//         {
//             ClaimsHelper.ClaimsToUser(principal);
//         });
//     }

//     [Fact]
//     public void ClaimsToUserThrowsExceptionIfLackValue()
//     {
//         // Arrange
//         var claims = new[]
//         {
//             new Claim(ClaimTypes.Name, "あああ"),
//             new Claim(ClaimTypes.Email, "hoge@example.com"),
//             new Claim(ClaimTypes.Role, "1"),
//         };
//         var identity = new ClaimsIdentity(claims, "Test");
//         var principal = new ClaimsPrincipal(identity);
//         // Act
//         // Assert
//         Assert.Throws<Exception>(() =>
//         {
//             ClaimsHelper.ClaimsToUser(principal);
//         });
//     }
//     #endregion

//     #region UserToClaimsのテスト
//     [Fact]
//     public void UserToClaimsReturnsValidValue()
//     {
//         // Arrange
//         User user = new User()
//         {
//             Id = 1,
//             Name = "あああ",
//             Email = "admin@example.com",
//             Role = User.RoleType.Guest,
//         };
//         // Act
//         var claims = ClaimsHelper.UserToClaims(user);
//         // Assert
//         Assert.Equal("1", claims.Find(c => c.Type == ClaimTypes.Sid)!.Value);
//         Assert.Equal("あああ", claims.Find(c => c.Type == ClaimTypes.Name)!.Value);
//         Assert.Equal("admin@example.com", claims.Find(c => c.Type == ClaimTypes.Email)!.Value);
//         Assert.Equal("Guest", claims.Find(c => c.Type == ClaimTypes.Role)!.Value);
//     }
//     #endregion
// }