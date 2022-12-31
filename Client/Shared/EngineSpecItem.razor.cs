using HogeBlazor.Client.Helpers;
using Microsoft.AspNetCore.Components;

namespace HogeBlazor.Client.Shared;
public partial class EngineSpecItem
{
    [Parameter]
    public Performance Perf { get; set; } = default!;

    public string ToString(float? value, string format = "{0:F1}")
    {
        return String.Format(format, value);
    }
}

