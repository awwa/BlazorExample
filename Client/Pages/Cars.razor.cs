using HogeBlazor.Client.Helpers;
using HogeBlazor.Client.Repositories;
using Microsoft.AspNetCore.Components;

namespace HogeBlazor.Client.Pages;
public partial class Cars
{
    public List<Car> CarList { get; set; } = new List<Car>();

    [Inject]
    public ICarHttpRepository CarRepo { get; set; } = default!;

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
        CarList = await CarRepo.GetCars();
    }
}
