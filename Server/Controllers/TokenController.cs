using System.IdentityModel.Tokens.Jwt;
using HogeBlazor.Server.Helpers;
using HogeBlazor.Shared.Helpers;
using HogeBlazor.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HogeBlazor.Server.Controllers;

[Route($"{Const.API_BASE_PATH_V1}[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;

    public TokenController(UserManager<User> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    [Route("refresh")]
    [HttpPost]
    public async Task<ActionResult<AuthResponseDto>> Refresh([FromBody] RefreshTokenDto tokenDto)
    {
        if (tokenDto is null)
        {
            return BadRequest(new AuthResponseDto { IsAuthSuccessful = false, ErrorMessage = "Invalid client request" });
        }

        var principal = _tokenService.GetPrincipalFromExpiredToken(tokenDto.Token);
        var username = principal?.Identity?.Name;

        var user = await _userManager.FindByEmailAsync(username);
        if (user == null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            return BadRequest(new AuthResponseDto { IsAuthSuccessful = false, ErrorMessage = "Invalid client request" });

        var signingCredentials = _tokenService.GetSigningCredentials();
        var claims = await _tokenService.GetClaims(user);
        var tokenOptions = _tokenService.GenerateTokenOptions(signingCredentials, claims);
        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        user.RefreshToken = _tokenService.GenerateRefreshToken();

        await _userManager.UpdateAsync(user);

        return Ok(new AuthResponseDto { Token = token, RefreshToken = user.RefreshToken, IsAuthSuccessful = true });
    }
}