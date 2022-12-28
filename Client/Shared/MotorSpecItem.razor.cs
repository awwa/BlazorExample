using HogeBlazor.Client.Helpers;
using Microsoft.AspNetCore.Components;

namespace HogeBlazor.Client.Shared;
public partial class MotorSpecItem
{
    [Parameter]
    public Performance Perf { get; set; } = default!;
}
