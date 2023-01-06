// using HogeBlazor.Shared.Models.Dto;
using HogeBlazor.Client.Models;
using Microsoft.AspNetCore.Components;

namespace HogeBlazor.Client.Shared;
public partial class MotorSpecItem
{
    [Parameter]
    public Ecr Ecr { get; set; } = default!;

    public string ToString(float? value, string format = "{0:F1}")
    {
        return value == null ? "ー" : String.Format(format, value);
    }
}
