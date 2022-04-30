using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HogeBlazor.Server.Helpers;
using HogeBlazor.Server.Models;
using HogeBlazor.Shared.Helpers;
using HogeBlazor.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HogeBlazor.Server.Controllers;

[Route($"{Const.API_BASE_PATH_V1}[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;

    public AccountsController(UserManager<User> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    [Route("register")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<ActionResult<RegistrationResponseDto>> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
    {
        if (userForRegistration is null)
        {
            var descriptor = new ValidationProblemDetails(new Dictionary<string, string[]> { { "default", new[] { "userForRegistration is null" } } });
            return ValidationProblem(descriptor);
        }
        var user = new User { UserName = userForRegistration.Email, Email = userForRegistration.Email };
        var result = await _userManager.CreateAsync(user, userForRegistration.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description);
            var descriptor = new ValidationProblemDetails(new Dictionary<string, string[]> { { "default", errors.ToArray<string>() } });
            return ValidationProblem(descriptor);
        }
        // ユーザ登録時のデフォルトロール
        await _userManager.AddToRoleAsync(user, "Viewer");
        return CreatedAtAction(nameof(RegisterUser), new RegistrationResponseDto());
    }

    [Route("login")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthResponseDto))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AuthResponseDto))]
    public async Task<ActionResult<AuthResponseDto>> Login([FromBody] UserForAuthenticationDto userForAuthentication)
    {
        var user = await _userManager.FindByNameAsync(userForAuthentication.Email);

        if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
            return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });

        var signingCredentials = _tokenService.GetSigningCredentials();
        var claims = await _tokenService.GetClaims(user);
        var tokenOptions = _tokenService.GenerateTokenOptions(signingCredentials, claims);
        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        user.RefreshToken = _tokenService.GenerateRefreshToken();
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7).ToUniversalTime();

        await _userManager.UpdateAsync(user);

        return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token, RefreshToken = user.RefreshToken });
    }
}