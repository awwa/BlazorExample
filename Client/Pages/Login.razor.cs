using HogeBlazor.Client.Helpers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeBlazor.Client.Pages
{
    public partial class Login
    {
        private UserForAuthenticationDto _userForAuthentication = new UserForAuthenticationDto();

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; } = default!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;
        public bool ShowAuthError { get; set; }
        public string Error { get; set; } = default!;

        public async Task ExecuteLogin()
        {
            ShowAuthError = false;
            try
            {
                await AuthenticationService.Login(_userForAuthentication);
                NavigationManager.NavigateTo("/");
            }
            catch (ApiException<AuthResponseDto> ex)
            {
                Error = ex.Result.ErrorMessage;
                ShowAuthError = true;
            }
        }
    }
}