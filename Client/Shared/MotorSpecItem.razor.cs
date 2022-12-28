using Microsoft.AspNetCore.Components;

namespace HogeBlazor.Client.Shared;
public partial class MotorSpecItem
{
    [Parameter]
    public string EcrWltcTitle { get; set; } = string.Empty;

    [Parameter]
    public string EcrWltc { get; set; } = string.Empty;

    [Parameter]
    public string EcrWltcLTitle { get; set; } = string.Empty;

    [Parameter]
    public string EcrWltcL { get; set; } = string.Empty;

    [Parameter]
    public string EcrWltcMTitle { get; set; } = string.Empty;

    [Parameter]
    public string EcrWltcM { get; set; } = string.Empty;

    [Parameter]
    public string EcrWltcHTitle { get; set; } = string.Empty;

    [Parameter]
    public string EcrWltcH { get; set; } = string.Empty;

    [Parameter]
    public string MpcWltcTitle { get; set; } = string.Empty;

    [Parameter]
    public string MpcWltc { get; set; } = string.Empty;

    [Parameter]
    public string EcrJc08Title { get; set; } = string.Empty;

    [Parameter]
    public string EcrJc08 { get; set; } = string.Empty;

    [Parameter]
    public string MpcJc08Title { get; set; } = string.Empty;

    [Parameter]
    public string MpcJc08 { get; set; } = string.Empty;
}
