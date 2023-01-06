// using HogeBlazor.Client.Helpers;
using HogeBlazor.Client.Models;
using Microsoft.AspNetCore.Components;

namespace HogeBlazor.Client.Shared;
public partial class EngineSpecItem
{
    [Parameter]
    public Fcr Fcr { get; set; } = default!;

    public string ToString(float? value, string format = "{0:F1}")
    {
        return value == null ? "ー" : String.Format(format, value);
    }
}

