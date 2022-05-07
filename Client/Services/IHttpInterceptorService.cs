using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Toolbelt.Blazor;

namespace HogeBlazor.Client.Services;

public interface IHttpInterceptorService
{
    void RegisterEvent();

    Task InterceptBeforeHttpAsync(object sender, HttpClientInterceptorEventArgs e);

    void DisposeEvent();
}