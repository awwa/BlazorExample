
using System.Text;
using System.Text.Json;
using HogeBlazor.Shared.DTO;

namespace HogeBlazor.Client.HttpRepository;

public class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;

    public AuthenticationService(HttpClient client)
    {
        _client = client;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<RegistrationResponseDto> RegisterUser(UserForRegistrationDto userForRegistration)
    {
        var content = JsonSerializer.Serialize(userForRegistration);
        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

        var registrationResult = await _client.PostAsync("/api/v1/accounts/register", bodyContent);
        var registrationContent = await registrationResult.Content.ReadAsStringAsync();

        if (!registrationResult.IsSuccessStatusCode)
        {
            var result = JsonSerializer.Deserialize<RegistrationResponseDto>(registrationContent, _options);
            return result;
        }

        return new RegistrationResponseDto { IsSuccessfulRegistration = true };
    }
}