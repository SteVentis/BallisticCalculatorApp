using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Modules.Security.Domain.Dtos;
using Modules.Security.Domain.Errors;
using WebAppUI.Repository.Interfaces;

namespace WebAppUI.Pages;

public partial class Registration
{
    private UserRegistrationForm _userRegistration = new UserRegistrationForm();

    [Inject]
    public IAuthService AuthService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public bool ShowRegistrationErrors { get; set; }
    public Error Errors { get; set; }

    public async Task Register()
    {
        ShowRegistrationErrors = false;

        var result = await AuthService.RegisterUser(_userRegistration);
        if (!result.IsSuccess)
        {
            Errors = result.Error;
            ShowRegistrationErrors = true;
        }
        else
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
