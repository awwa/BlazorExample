using Microsoft.AspNetCore.Components;
using HogeBlazor.Client.Repositories;
using HogeBlazor.Shared.Models.Dto;

namespace HogeBlazor.Client.Shared;

public partial class BreadCrumb
{
    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    [Inject]
    [Parameter]
    public ICarHttpRepository CarRepo { get; set; } = default!;

    public IList<BreadCrumbItem> Items { get; set; } = new List<BreadCrumbItem>();

    private Dictionary<string, string> _pages = new Dictionary<string, string>()
    {
        { "cars", "クルマ一覧" },
    };

    protected async override Task OnInitializedAsync()
    {
        Items = await BuildItemsAsync(NavigationManager.Uri);
    }

    public async Task<IList<BreadCrumbItem>> BuildItemsAsync(string uri)
    {
        var relativePath = $"/{NavigationManager.ToBaseRelativePath(uri)}";
        var ret = new List<BreadCrumbItem>();
        ret.Add(new BreadCrumbItem() { Path = "/", Text = "ホーム" });

        var path = "/";
        string[] items = relativePath.Split('/', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        for (var i = 0; i < items.Count(); i++)
        {
            string text = _pages.ContainsKey(items[i]) ? _pages[items[i]] : items[i];
            if (i == 0)
            {
                path += items[i];
            }
            else
            {
                path += "/" + items[i];
            }
            if (items[i].StartsWith("car_"))
            {
                CarDto car = await CarRepo.GetCarAsync(items[i]);
                text = car.ModelName ?? string.Empty;
            }
            // 末尾のリンクは無効
            if (i == items.Count() - 1) path = "";
            ret.Add(new BreadCrumbItem() { Path = path, Text = text });
        }
        return ret;
    }
}

public class BreadCrumbItem
{
    public string Path { get; set; } = default!;
    public string Text { get; set; } = default!;
}

