using HogeBlazor.Client.Helpers;
using Microsoft.AspNetCore.Components;

namespace HogeBlazor.Client.Shared;
public partial class EngineSpecItem
{
    [Parameter]
    public Performance Perf { get; set; } = default!;
}
