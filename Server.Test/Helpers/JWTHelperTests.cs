using HogeBlazor.Server.Controllers;
using HogeBlazor.Shared.Models;
using HogeBlazor.Server.Helpers;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Moq;
using Microsoft.AspNetCore.Mvc;
using static HogeBlazor.Server.Controllers.UsersController;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.Data.Sqlite;
using JWT.Exceptions;

namespace HogeBlazor.Server.Test.Controllers;

public class JWTHelperTests
{
    [Fact]
    public void EncodeAndDecodeSuccess()
    {
        var userOrg = new User() { Id = 1, Name = "ほげ 太郎", Email = "admin@example.com", Role = User.RoleType.Admin, PlainPassword = "password" };
        string token = JWTHelper.Encode(userOrg);
        User userDcd = JWTHelper.Decode(token);
        Assert.Equal(userOrg.Id, userDcd.Id);
    }

    [Fact]
    public void DecodeThrowsExceptionIfTokenIsInvalid()
    {
        string token = "invalid value";
        Assert.Throws<InvalidTokenPartsException>("token", () => JWTHelper.Decode(token));

    }

}