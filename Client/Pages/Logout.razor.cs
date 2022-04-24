using HogeBlazor.Client.HttpRepository;
using Microsoft.AspNetCore.Components;

namespace HogeBlazor.Client.Pages;
public partial class Logout
{
    [Inject]
    public IAuthenticationService AuthenticationService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await AuthenticationService.Logout();
        NavigationManager.NavigateTo("/");
    }
}