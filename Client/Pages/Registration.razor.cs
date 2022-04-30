using HogeBlazor.Client.Helpers;
using HogeBlazor.Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeBlazor.Client.Pages
{
    public partial class Registration
    {
        private UserForRegistrationDto _userForRegistration = new UserForRegistrationDto();

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; } = default!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;
        public bool ShowRegistrationErrors { get; set; }
        public IEnumerable<string> Errors { get; set; } = new List<string>();

        public async Task Register()
        {
            ShowRegistrationErrors = false;
            try
            {
                await AuthenticationService.RegisterUser(_userForRegistration);
                NavigationManager.NavigateTo("/");
            }
            catch (ApiException<ValidationProblemDetails> ex)
            {
                var key = ex.Result.Errors.Keys.FirstOrDefault<string>("default");
                Errors = ex.Result.Errors[key];
                ShowRegistrationErrors = true;
            }
        }
    }
}