using Xunit;
using HogeBlazor.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace HogeBlazor.Shared.Test.Models;

// ASP.NET5 MVC6 でのModelStateの単体テスト
// https://blog.beachside.dev/entry/2016/02/02/190000
public class UserTests
{
    #region コンストラクタに対するテスト
    /// <summary>
    /// コンストラクタで指定できるプロパティ値の確認
    /// </summary>
    [Fact]
    public void ConstructorSetPropertyValue()
    {
        var user = new User(name: "ほげ 太郎", email: "hoge@example.com", plainPassword: "password", role: User.RoleType.Admin) { Id = 1 };
        Assert.Equal(1, user.Id);
        Assert.Equal("ほげ 太郎", user.Name);
        Assert.Equal("hoge@example.com", user.Email);
        Assert.Equal("password", user.PlainPassword);
        Assert.NotEqual("password", user.HashedPassword);
        Assert.Equal(User.RoleType.Admin, user.Role);
        Assert.Equal(new DateTime(), user.CreatedAt);
        Assert.Equal(new DateTime(), user.UpdatedAt);
        Assert.False(user.IsDel);
    }

    [Fact]
    public void ConstructorCreateInstanceSuccessfully()
    {
        // Arrange
        var user = new User(name: "ほげ 太郎", email: "hoge@example.com", plainPassword: "password", role: User.RoleType.Admin) { };
        var context = new ValidationContext(user, null, null);
        var result = new List<ValidationResult>();
        // Act
        var validationResult = Validator.TryValidateObject(user, context, result, true);
        // Assert
        Assert.True(validationResult);
    }
    #endregion

    #region Nameプロパティに対するテスト
    [Fact]
    public void ValidateNameRequired()
    {
        // Arrange
        var user = new User(name: "", email: "hoge@example.com", plainPassword: "password", role: User.RoleType.Admin) { };
        var context = new ValidationContext(user, null, null);
        var result = new List<ValidationResult>();
        // Act
        var validationResult = Validator.TryValidateObject(user, context, result, true);
        // Assert
        Assert.False(validationResult);
        Assert.Contains(result, r => r.MemberNames.Contains("Name"));
    }
    [Fact]
    public void ValidateNameMaxLength()
    {
        // Arrange
        var user = new User(name: new string('あ', 100), email: "hoge@example.com", plainPassword: "password", role: User.RoleType.Admin) { };
        var context = new ValidationContext(user, null, null);
        var result = new List<ValidationResult>();
        // Act
        var validationResult = Validator.TryValidateObject(user, context, result, true);
        // Assert
        Assert.True(validationResult);
    }
    [Fact]
    public void ValidateNameOverMaxLength()
    {
        // Arrange
        var user = new User(name: new string('あ', 101), email: "hoge@example.com", plainPassword: "password", role: User.RoleType.Admin) { };
        var context = new ValidationContext(user, null, null);
        var result = new List<ValidationResult>();
        // Act
        var validationResult = Validator.TryValidateObject(user, context, result, true);
        // Assert
        Assert.False(validationResult);
        Assert.Contains(result, r => r.MemberNames.Contains("Name"));
    }
    #endregion

    #region Emailプロパティに対するテスト
    [Fact]
    public void ValidateEmailRequired()
    {
        // Arrange
        var user = new User(name: "ほげ 太郎", email: "", plainPassword: "password", role: User.RoleType.Admin) { };
        var context = new ValidationContext(user, null, null);
        var result = new List<ValidationResult>();
        // Act
        var validationResult = Validator.TryValidateObject(user, context, result, true);
        // Assert
        Assert.False(validationResult);
        Assert.Contains(result, r => r.MemberNames.Contains("Email"));
    }
    [Fact]
    public void ValidateEmailMaxLength()
    {
        // Arrange
        var user = new User(name: "ほげ 太郎", email: (new string('a', 88)) + "@example.com", plainPassword: "password", role: User.RoleType.Admin) { };
        var context = new ValidationContext(user, null, null);
        var result = new List<ValidationResult>();
        // Act
        var validationResult = Validator.TryValidateObject(user, context, result, true);
        // Assert
        Assert.True(validationResult);
    }
    [Fact]
    public void ValidateEmailOverMaxLength()
    {
        // Arrange
        var user = new User(name: "ほげ 太郎", email: (new string('a', 89)) + "@example.com", plainPassword: "password", role: User.RoleType.Admin) { };
        var context = new ValidationContext(user, null, null);
        var result = new List<ValidationResult>();
        // Act
        var validationResult = Validator.TryValidateObject(user, context, result, true);
        // Assert
        Assert.False(validationResult);
        Assert.Contains(result, r => r.MemberNames.Contains("Email"));
    }
    [Fact]
    public void ValidateEmailFormat()
    {
        // Arrange
        var user = new User(name: "ほげ 太郎", email: "invalid format", plainPassword: "password", role: User.RoleType.Admin) { };
        var context = new ValidationContext(user, null, null);
        var result = new List<ValidationResult>();
        // Act
        var validationResult = Validator.TryValidateObject(user, context, result, true);
        // Assert
        Assert.False(validationResult);
        Assert.Contains(result, r => r.MemberNames.Contains("Email"));
    }
    #endregion

    #region PlainPasswordプロパティに対するテスト
    [Fact]
    public void ValidatePlainPasswordRequired()
    {
        // Arrange
        var user = new User(name: "ほげ 太郎", email: "admin@example.com", plainPassword: "", role: User.RoleType.Admin) { };
        var context = new ValidationContext(user, null, null);
        var result = new List<ValidationResult>();
        // Act
        var validationResult = Validator.TryValidateObject(user, context, result, true);
        // Assert
        Assert.False(validationResult);
        Assert.Contains(result, r => r.MemberNames.Contains("PlainPassword"));
    }
    [Fact]
    public void ValidatePlainPasswordMaxLength()
    {
        // Arrange
        var user = new User(name: "ほげ 太郎", email: "admin@example.com", plainPassword: new string('a', 100), role: User.RoleType.Admin) { };
        var context = new ValidationContext(user, null, null);
        var result = new List<ValidationResult>();
        // Act
        var validationResult = Validator.TryValidateObject(user, context, result, true);
        // Assert
        Assert.True(validationResult);
    }
    [Fact]
    public void ValidatePlainPasswordOverMaxLength()
    {
        // Arrange
        var user = new User(name: "ほげ 太郎", email: "admin@example.com", plainPassword: new string('a', 101), role: User.RoleType.Admin) { };
        var context = new ValidationContext(user, null, null);
        var result = new List<ValidationResult>();
        // Act
        var validationResult = Validator.TryValidateObject(user, context, result, true);
        // Assert
        Assert.False(validationResult);
        Assert.Contains(result, r => r.MemberNames.Contains("PlainPassword"));
    }
    [Fact]
    public void ValidatePlainPasswordMinLength()
    {
        // Arrange
        var user = new User(name: "ほげ 太郎", email: "admin@example.com", plainPassword: "12345678", role: User.RoleType.Admin) { };
        var context = new ValidationContext(user, null, null);
        var result = new List<ValidationResult>();
        // Act
        var validationResult = Validator.TryValidateObject(user, context, result, true);
        // Assert
        Assert.True(validationResult);
    }
    [Fact]
    public void ValidatePlainPasswordUnderMinLength()
    {
        // Arrange
        var user = new User(name: "ほげ 太郎", email: "admin@example.com", plainPassword: "1234567", role: User.RoleType.Admin) { };
        var context = new ValidationContext(user, null, null);
        var result = new List<ValidationResult>();
        // Act
        var validationResult = Validator.TryValidateObject(user, context, result, true);
        // Assert
        Assert.False(validationResult);
        Assert.Contains(result, r => r.MemberNames.Contains("PlainPassword"));
    }
    #endregion
}