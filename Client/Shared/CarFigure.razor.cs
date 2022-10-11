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
            Type = "SUV",
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
}