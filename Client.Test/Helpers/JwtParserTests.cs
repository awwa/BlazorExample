using System;
using System.Linq;
using HogeBlazor.Client.Helpers;

namespace HogeBlazor.Client.Test.Features;

public class JwtParserTests : TestContext
{
    [Fact]
    public void ParseClaimsFromJwt()
    {
        // Arrang & Act
        var claims = JwtParser.ParseClaimsFromJwt("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoid2F0YXJ1KzJAa2tlLmNvLmpwIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVmlld2VyIiwiZXhwIjoxNjUxMjIxMjkzLCJpc3MiOiJDb2RlTWF6ZUFQSSIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMTEifQ.xrhU718CCmntsNYnDtuYkCYu2KfAeCMuVHvw_cQ2u4k");
        // Assert
        var cc = claims.Select(c => c.Type);
        Assert.Contains("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", cc);
        Assert.Contains("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", cc);
        Assert.Contains("exp", cc);
        Assert.Contains("iss", cc);
        Assert.Contains("aud", cc);
        foreach (var c in claims)
        {
            switch (c.Type)
            {
                case "http://schemas.microsoft.com/ws/2008/06/identity/claims/role":
                    Assert.Equal("Viewer", c.Value);
                    break;
                case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name":
                    Assert.Equal("wataru+2@kke.co.jp", c.Value);
                    break;
                case "exp":
                    Assert.Equal("1651221293", c.Value);
                    break;
                case "iss":
                    Assert.Equal("CodeMazeAPI", c.Value);
                    break;
                case "aud":
                    Assert.Equal("https://localhost:5011", c.Value);
                    break;
            }
        }
    }
}
