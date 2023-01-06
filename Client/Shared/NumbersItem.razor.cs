using Microsoft.AspNetCore.Components;

namespace HogeBlazor.Client.Shared;
public partial class NumbersItem
{
    [Parameter]
    public List<KeyValuePair<string, string>> KVPairs { get; set; } = default!;
}
