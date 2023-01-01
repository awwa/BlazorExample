using Microsoft.AspNetCore.Components.Authorization;

namespace HogeBlazor.Client.Services;

public class RefreshTokenService
{
    private readonly AuthenticationStateProvider _authProvider;
    private readonly IAuthenticationService _authService;

    public RefreshTokenService(AuthenticationStateProvider authProvider, IAuthenticationService authService)
    {
        _authProvider = authProvider;
        _authService = authService;
    }

    public async Task<string> TryRefreshToken()
    {
        Console.WriteLine("TryRefreshToken()1");
        var authState = await _authProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        Console.WriteLine("TryRefreshToken()2");
        var claim = user.FindFirst(c => c.Type.Equals("exp"));
        if (claim == null) throw new ArgumentNullException();
        var exp = claim.Value;
        var expTime = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(exp));

        Console.WriteLine("TryRefreshToken()3");
        var timeUTC = DateTime.UtcNow;

        var diff = expTime - timeUTC;
        if (diff.TotalMinutes <= 2)
        {
            Console.WriteLine("TryRefreshToken()4");
            return await _authService.RefreshToken();
        }

        Console.WriteLine("TryRefreshToken()5");
        return string.Empty;
    }
}