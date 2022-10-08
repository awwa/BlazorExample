using Microsoft.JSInterop;

namespace HogeBlazor.Client.Shared;
public partial class CarFigure
{
    protected async override Task OnInitializedAsync()
    {
        var module = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./Shared/CarFigure.razor.js");
        await module.InvokeVoidAsync("drawCar");
    }
}