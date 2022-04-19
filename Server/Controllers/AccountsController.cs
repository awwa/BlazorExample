using HogeBlazor.Server.Helpers;
using HogeBlazor.Shared.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HogeBlazor.Server.Controllers;

[ApiController]
public class AccountsController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;

    public AccountsController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    // [Route("api/accounts")]
    // [HttpPost("Registration")]
    [Route(Const.API_BASE_PATH_V1 + "[controller]/register")]
    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
    {
        if (userForRegistration == null || !ModelState.IsValid)
        {
            return BadRequest();
        }

        var user = new IdentityUser { UserName = userForRegistration.Email, Email = userForRegistration.Email };
        var result = await _userManager.CreateAsync(user, userForRegistration.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description);
            return BadRequest(new RegistrationResponseDto { Errors = errors });
        }
        return StatusCode(201);
    }
}