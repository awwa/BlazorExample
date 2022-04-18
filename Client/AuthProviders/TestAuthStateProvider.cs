using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

public class TestAuthStateProvider : AuthenticationStateProvider
{
  public async override Task<AuthenticationState> GetAuthenticationStateAsync()
  {
    await Task.Delay(1500);
    var claims = new List<Claim>()
    {
        new Claim(ClaimTypes.Name, "ほげ"),
        new Claim(ClaimTypes.Role, "Admin"),
    };
    // var anonymous = new ClaimsIdentity();
    var anonymous = new ClaimsIdentity(claims, "testAuthType");
    return await Task.FromResult(new AuthenticationState(new System.Security.Claims.ClaimsPrincipal(anonymous)));
  }
}