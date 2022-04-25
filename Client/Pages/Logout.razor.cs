using HogeBlazor.Client.HttpRepository;
using Microsoft.AspNetCore.Components;

namespace HogeBlazor.Client.Pages;
public partial class Logout
{
    [Inject]
    public IAuthenticationService AuthenticationService { get; set; } = default!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        await AuthenticationService.Logout();
        NavigationManager.NavigateTo("/");
    }
}