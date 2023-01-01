using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Toolbelt.Blazor;

namespace HogeBlazor.Client.Services;

public class HttpInterceptorService
{
    private readonly HttpClientInterceptor _interceptor;
    private readonly RefreshTokenService _refreshTokenService;

    public HttpInterceptorService(HttpClientInterceptor interceptor, RefreshTokenService refreshTokenService)
    {
        _interceptor = interceptor;
        _refreshTokenService = refreshTokenService;
    }

    public void RegisterEvent() => _interceptor.BeforeSendAsync += InterceptBeforeHttpAsync;

    public async Task InterceptBeforeHttpAsync(object sender, HttpClientInterceptorEventArgs e)
    {
        Console.WriteLine("InterceptBeforeHttpAsync()1");
        // TODO nullチェックを改善したい
        if (e == null) throw new ArgumentNullException();
        Console.WriteLine("InterceptBeforeHttpAsync()2");
        if (e.Request == null) throw new ArgumentNullException();
        Console.WriteLine("InterceptBeforeHttpAsync()3");
        if (e.Request.RequestUri == null) throw new ArgumentNullException();
        Console.WriteLine("InterceptBeforeHttpAsync()4");
        var absPath = e.Request.RequestUri.AbsolutePath;

        if (!absPath.Contains("token") && !absPath.Contains("accounts"))
        {
            Console.WriteLine("InterceptBeforeHttpAsync()5");
            var token = await _refreshTokenService.TryRefreshToken();

            if (!string.IsNullOrEmpty(token))
            {
                Console.WriteLine("InterceptBeforeHttpAsync()6");
                e.Request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);
            }
        }
    }

    public void DisposeEvent() => _interceptor.BeforeSendAsync -= InterceptBeforeHttpAsync;
}