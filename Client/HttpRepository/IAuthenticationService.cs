
using HogeBlazor.Shared.DTO;

namespace HogeBlazor.Client.HttpRepository;

public interface IAuthenticationService
{
    Task<RegistrationResponseDto> RegisterUser(UserForRegistrationDto userForRegistration);
}