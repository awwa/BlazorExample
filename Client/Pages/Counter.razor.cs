using HogeBlazor.Client.Helpers;
using HogeBlazor.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace HogeBlazor.Client.Pages;

public partial class Counter
{
    [Inject]
    public HttpInterceptorService Interceptor { get; set; } = default!;

    private int currentCount = 0;

    [CascadingParameter]
    public Task<AuthenticationState> AuthState { get; set; }

    private async Task IncrementCount()
    {
        var authState = await AuthState;
        var user = authState.User;

        if (user.Identity.IsAuthenticated)
            currentCount++;
        else
            currentCount--;
    }
}