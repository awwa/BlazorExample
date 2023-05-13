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

    IEnumerable<MakerName> MakerNames = new List<MakerName>();

    [Inject]
    public ICarHttpRepository CarRepo { get; set; } = default!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    class MakerName
    {
        public string Name { get; set; } = string.Empty;
    }

    protected async override Task OnInitializedAsync()
    {
        // await GetCars();
        IEnumerable<string> names = await CarRepo.GetCarAttributeValuesAsync("MakerName");
        MakerNames = names.Select(name => new MakerName { Name = name }); // new List<MakerName> { new MakerName { Name = "あいう" }, new MakerName { Name = "えおか" } };//
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
