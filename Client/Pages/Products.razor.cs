using HogeBlazor.Client.Helpers;
using HogeBlazor.Client.Repositories;
using HogeBlazor.Client.Services;
using Microsoft.AspNetCore.Components;

namespace HogeBlazor.Client.Pages;
public partial class Products : IDisposable
{
    public List<Product> ProductList { get; set; } = new List<Product>();

    [Inject]
    public IProductHttpRepository ProductRepo { get; set; } = default!;

    [Inject]
    public HttpInterceptorService Interceptor { get; set; } = default!;

    protected async override Task OnInitializedAsync()
    {
        Interceptor.RegisterEvent();
        await GetProducts();
    }

    private async Task SelectedPage(int page)
    {
        await GetProducts();
    }

    private async Task GetProducts()
    {
        ProductList = await ProductRepo.GetProducts();
    }

    public void Dispose() => Interceptor.DisposeEvent();
}
