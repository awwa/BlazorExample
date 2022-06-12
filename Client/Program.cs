using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using HogeBlazor.Client;
using Radzen;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using HogeBlazor.Client.Helpers;
using HogeBlazor.Client.Repositories;
using HogeBlazor.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
}
.EnableIntercept(sp));
builder.Services.AddScoped<DialogService>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddHttpClientInterceptor();
builder.Services.AddScoped<ICarHttpRepository, CarHttpRepository>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<RefreshTokenService>();
builder.Services.AddScoped<HttpInterceptorService>();

await builder.Build().RunAsync();
