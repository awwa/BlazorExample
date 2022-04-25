using System.Security.Claims;
using HogeBlazor.Client.HttpRepository;
using HogeBlazor.Shared.Models;
using HogeBlazor.Shared.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace HogeBlazor.Client.Pages;
public partial class Products : IDisposable
{
    public List<Product> ProductList { get; set; } = new List<Product>();
    public MetaData MetaData { get; set; } = default!;
    // private ProductParameters _productParameters = new ProductParameters();

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
        //_productParameters.PageNumber = page;
        await GetProducts();
    }

    private async Task GetProducts()
    {
        var pagingResponse = await ProductRepo.GetProducts();
        ProductList = pagingResponse.Items;
    }

    public void Dispose() => Interceptor.DisposeEvent();
}
