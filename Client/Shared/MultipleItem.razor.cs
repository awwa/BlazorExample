using Microsoft.AspNetCore.Components;

namespace HogeBlazor.Client.Shared;
public partial class MultipleItem
{
    [Parameter]
    public string Name { get; set; } = string.Empty;

    [Parameter]
    public List<KeyValuePair<string, string>> KVPairs { get; set; } = default!;
}
