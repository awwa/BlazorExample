using Xunit;
using HogeBlazor.Shared.Models;
using System;

namespace HogeBlazor.Shared.Test.Models;

public class UserTests
{
    /// <summary>
    /// コンストラクタで指定できるプロパティ値の確認
    /// </summary>
    [Fact]
    public void ConstructorSetPropertyValue()
    {
        var user = new User(id: 1, name: "ほげ 太郎", email: "hoge@example.com", role: User.RoleType.Admin);
        Assert.Equal(1, user.Id);
        Assert.Equal("ほげ 太郎", user.Name);
        Assert.Equal("hoge@example.com", user.Email);
        Assert.Equal("", user.Password);
        Assert.Equal(User.RoleType.Admin, user.Role);
        Assert.Equal(new DateTime(), user.CreatedAt);
        Assert.Equal(new DateTime(), user.UpdatedAt);
        Assert.Equal(false, user.IsDel);
    }

    /// <summary>
    /// 平文のパスワードを与えるとハッシュ化された値が設定される
    /// </summary>
    [Fact]
    public void PasswordReturnsHashedValue()
    {
        var user = new User(id: 1, name: "ほげ 太郎", email: "hoge@example.com", role: User.RoleType.Admin);
        user.Password = "password";
        Assert.NotEqual("password", user.Password);
    }
}