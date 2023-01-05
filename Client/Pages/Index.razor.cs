using Microsoft.AspNetCore.Components;

namespace HogeBlazor.Client.Pages;
public partial class Index
{
    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    protected override void OnInitialized()
    {
        // 現時点では無条件にクルマ一覧画面に遷移する
        NavigationManager.NavigateTo($"/cars");
    }
}
