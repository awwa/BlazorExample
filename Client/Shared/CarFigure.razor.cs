using HogeBlazor.Client.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace HogeBlazor.Client.Shared;
public partial class CarFigure
{
    [Parameter]
    public Car Car { get; set; } = default!;

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