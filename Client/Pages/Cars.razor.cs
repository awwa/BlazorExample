using HogeBlazor.Client.Models;
using HogeBlazor.Client.Repositories;
using Microsoft.AspNetCore.Components;
using System.Linq;

namespace HogeBlazor.Client.Pages;
public partial class Cars
{
    public List<CarDisp> CarList { get; set; } = new List<CarDisp>();

    bool OuterBodyVisible = false;
    bool PerformanceVisible = false;
    bool EngineVisible = false;
    bool MotorVisible = false;
    bool OtherVisible = false;

    [Inject]
    public ICarHttpRepository CarRepo { get; set; } = default!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    private string ConvertForDisplay<T>(string? value)
    {
        return CommentHelper.GetCommentAttributeOnField<T>(value);
    }

    protected async override Task OnInitializedAsync()
    {
        await GetCars();
    }

    private async Task SelectedPage(int page)
    {
        await GetCars();
    }

    private async Task GetCars()
    {
        var list = await CarRepo.GetCars();
        CarList = list.Select(c => new CarDisp(c)).ToList<CarDisp>();
    }

    public void OnRowSelect(object value)
    {
        if (value is CarDisp)
        {
            NavigationManager.NavigateTo($"/cars/{((CarDisp)value).Id}");
        }
    }
}
