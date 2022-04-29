using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace HogeBlazor.Client.Helpers;

public class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;
    private readonly AuthenticationStateProvider _authProvider;
    private readonly ILocalStorageService _localStorage;

    public AuthenticationService(HttpClient client, AuthenticationStateProvider authProvider, ILocalStorageService localStorage)
    {
        _client = client;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        _authProvider = authProvider;
        _localStorage = localStorage;
    }

    public async Task<RegistrationResponseDto> RegisterUser(UserForRegistrationDto userForRegistration)
    {
        var client = new AccountsClient("", _client);
        await client.RegisterUserAsync(userForRegistration);
        return new RegistrationResponseDto();
    }
    public async Task<AuthResponseDto> Login(UserForAuthenticationDto userForAuthentication)
    {
        var client = new AccountsClient("", _client);
        var result = await client.LoginAsync(userForAuthentication);
        // ローカルストレージにトークンを保存
        await _localStorage.SetItemAsync("authToken", result.Token);
        ((AuthStateProvider)_authProvider).NotifyUserAuthentication(result.Token);
        await _localStorage.SetItemAsync("refreshToken", result.RefreshToken);
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);

        return new AuthResponseDto { IsAuthSuccessful = true };
    }

    public async Task Logout()
    {
        // ローカルストレージのトークンをクリア
        await _localStorage.RemoveItemAsync("authToken");
        await _localStorage.RemoveItemAsync("refreshToken");
        ((AuthStateProvider)_authProvider).NotifyUserLogout();
        _client.DefaultRequestHeaders.Authorization = null;
    }

    public async Task<string> RefreshToken()
    {
        var token = await _localStorage.GetItemAsync<string>("authToken");
        var refreshToken = await _localStorage.GetItemAsync<string>("refreshToken");
        var tokenDto = new RefreshTokenDto { Token = token, RefreshToken = refreshToken };
        var client = new TokenClient("", _client);
        var result = await client.RefreshAsync(tokenDto);
        // ローカルストレージのトークンを更新
        await _localStorage.SetItemAsync("authToken", result.Token);
        await _localStorage.SetItemAsync("refreshToken", result.RefreshToken);

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);

        return result.Token;
    }
}