using HogeBlazor.Client.Helpers;

namespace HogeBlazor.Client.Services;

public interface IAuthenticationService
{
    Task<RegistrationResponseDto> RegisterUser(UserForRegistrationDto userForRegistration);
    Task<AuthResponseDto> Login(UserForAuthenticationDto userForAuthentication);
    Task Logout();
    Task<string> RefreshToken();
}