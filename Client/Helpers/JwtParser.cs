using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HogeBlazor.Client.Helpers;

public static class JwtParser
{
    public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var jwtToken = new JwtSecurityToken(jwt);
        return jwtToken.Claims;
    }
}
