using HogeBlazor.Client.Helpers;
using HogeBlazor.Client.Pages;
using HogeBlazor.Client.Repositories;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace HogeBlazor.Client.Test.Pages;
public class BaseTestContext : TestContext
{
    public BaseTestContext()
    {
        this.JSInterop.Setup<string>("localStorage.getItem", "authToken");
        this.AddTestAuthorization();
        this.Services.AddBlazoredLocalStorage();
        this.Services.AddAuthorizationCore();
        this.Services.AddHttpClientInterceptor();
        this.Services.AddScoped<ICarHttpRepository, CarHttpRepository>();
        this.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
    }
}