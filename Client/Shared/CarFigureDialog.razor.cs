using HogeBlazor.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;

namespace HogeBlazor.Client.Shared;
public partial class CarFigureDialog
{
    [Parameter]
    public CarDisp Car { get; set; } = default!;

    [Inject]
    public DialogService DialogService { get; set; } = default!;

    protected async override Task OnInitializedAsync()
    {
        var module = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./Shared/CarFigure.razor.js");
        await module.InvokeVoidAsync(
            "drawCar",
            Car.BodyType,
            Car.OuterBody.Length,
            Car.OuterBody.Width,
            Car.OuterBody.Height,
            Car.OuterBody.WheelBase,
            Car.OuterBody.TreadFront,
            Car.OuterBody.TreadRear,
            Car.OuterBody.MinRoadClearance
        );
    }
}