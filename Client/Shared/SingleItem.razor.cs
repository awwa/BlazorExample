using Microsoft.AspNetCore.Components;

namespace HogeBlazor.Client.Shared;
public partial class SingleItem
{
    [Parameter]
    public string Name { get; set; } = string.Empty;

    [Parameter]
    public string Value { get; set; } = string.Empty;
}
