using HogeBlazor.Shared.Models.Dto;
using HogeBlazor.Client.Repositories;
using Microsoft.AspNetCore.Components;
using System.Linq;

namespace HogeBlazor.Client.Pages;
public partial class Cars
{
    private List<CarDto> Items { get; set; } = new List<CarDto>();

    bool OuterBodyVisible = false;
    bool PerformanceVisible = false;
    bool EngineVisible = false;
    bool MotorVisible = false;
    bool OtherVisible = false;
    CarQuery Query = new CarQuery();

    IEnumerable<string> MakerNames = new List<string>();

    IEnumerable<PowerTrain> PowerTrains = PowerTrain.CreateItems();

    IEnumerable<DriveSystem> DriveSystems = DriveSystem.CreateItems();

    IEnumerable<BodyType> BodyTypes = BodyType.CreateItems();

    IEnumerable<FuelType> FuelTypes = FuelType.CreateItems();

    [Inject]
    public ICarHttpRepository CarRepo { get; set; } = default!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    protected async override Task OnInitializedAsync()
    {
        // await GetCars();
        MakerNames = await CarRepo.GetCarAttributeValuesAsync("MakerName");
    }

    private async Task GetCars()
    {
        Dictionary<string, CarDto> dic = (Dictionary<string, CarDto>)await CarRepo.QueryCarsAsync(Query);
        Items = dic.Values.ToList();
    }

    public void OnRowSelect(object value)
    {
        // if (value is CarDisp)
        // {
        //     NavigationManager.NavigateTo($"/cars/{((CarDisp)value).Id}");
        // }
    }
}
