using Microsoft.AspNetCore.Components;

namespace HogeBlazor.Client.Shared;
public partial class ListItem
{
    [Parameter]
    public string Name { get; set; } = string.Empty;

    [Parameter]
    public ICollection<string> Values { get; set; } = default!;
}
