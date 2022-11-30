using HogeBlazor.Client.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace HogeBlazor.Client.Shared;
public partial class CarFigure
{
    [Parameter]
    public Car Car { get; set; } = new Car
    {
        Body = new Body()
        {
            // Type = "SUV",
            Type = HogeBlazor.Shared.Models.Db.BodyType.STATION_WAGON,//.HATCHBACK,
            Length = 4545,
            Width = 1840,
            Height = 1690,
            WheelBase = 2700,
            TreadFront = 1595,
            TreadRear = 1595,
            MinRoadClearance = 210,
            Weight = 1620,
            DoorNum = 4,
        },
        Interior = new Interior(),
        Performance = new Performance(),
        Engine = new Engine(),
        MotorX = new Motor(),
        MotorY = new Motor(),
        Battery = new Battery(),
        TireFront = new Tire(),
        TireRear = new Tire(),
        Transmission = new Transmission(),
    };

    [Parameter]
    public List<string> BodyTypes { get; set; } = new List<string>()
    {
        HogeBlazor.Shared.Models.Db.BodyType.SEDAN,
        HogeBlazor.Shared.Models.Db.BodyType.COUPE,
        HogeBlazor.Shared.Models.Db.BodyType.HATCHBACK,
        HogeBlazor.Shared.Models.Db.BodyType.STATION_WAGON,
        HogeBlazor.Shared.Models.Db.BodyType.SUV,
        HogeBlazor.Shared.Models.Db.BodyType.CROSS_COUNTRY,
        HogeBlazor.Shared.Models.Db.BodyType.ONEBOX,
        HogeBlazor.Shared.Models.Db.BodyType.OPEN,
        HogeBlazor.Shared.Models.Db.BodyType.PICKUP_TRUCK,
        HogeBlazor.Shared.Models.Db.BodyType.K,
        HogeBlazor.Shared.Models.Db.BodyType.K_ONEBOX,
        HogeBlazor.Shared.Models.Db.BodyType.K_OPEN,
    };
    protected async override Task OnInitializedAsync()
    {
        var module = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./Shared/CarFigure.razor.js");
        await module.InvokeVoidAsync(
            "drawCar",
            Car.Body.Type,
            Car.Body.Length,
            Car.Body.Width,
            Car.Body.Height,
            Car.Body.WheelBase,
            Car.Body.TreadFront,
            Car.Body.TreadRear,
            Car.Body.MinRoadClearance
        );
    }

    async Task ChangeDropDown(object value)
    {
        var str = value is IEnumerable<string> ? string.Join(", ", (IEnumerable<string>)value) : (string)value;

        Console.WriteLine($"Value changed to {str}");
        await RefreshBody(str);
    }

    async Task RefreshBody(string bodyType)
    {
        Car.Body.Type = bodyType;

        var module = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./Shared/CarFigure.razor.js");
        await module.InvokeVoidAsync(
            "drawCar",
            Car.Body.Type,
            Car.Body.Length,
            Car.Body.Width,
            Car.Body.Height,
            Car.Body.WheelBase,
            Car.Body.TreadFront,
            Car.Body.TreadRear,
            Car.Body.MinRoadClearance
        );

        Console.WriteLine($"BodyType changed to {bodyType}");
    }
}