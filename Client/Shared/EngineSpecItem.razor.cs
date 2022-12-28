using Microsoft.AspNetCore.Components;

namespace HogeBlazor.Client.Shared;
public partial class EngineSpecItem
{
    [Parameter]
    public string FcrWltcTitle { get; set; } = string.Empty;

    [Parameter]
    public string FcrWltc { get; set; } = string.Empty;

    [Parameter]
    public string FcrWltcLTitle { get; set; } = string.Empty;

    [Parameter]
    public string FcrWltcL { get; set; } = string.Empty;

    [Parameter]
    public string FcrWltcMTitle { get; set; } = string.Empty;

    [Parameter]
    public string FcrWltcM { get; set; } = string.Empty;

    [Parameter]
    public string FcrWltcHTitle { get; set; } = string.Empty;

    [Parameter]
    public string FcrWltcH { get; set; } = string.Empty;

    [Parameter]
    public string FcrJc08Title { get; set; } = string.Empty;

    [Parameter]
    public string FcrJc08 { get; set; } = string.Empty;
}
