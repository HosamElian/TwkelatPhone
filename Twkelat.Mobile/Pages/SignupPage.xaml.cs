using Twkelat.Mobile.Models.Request;
using Twkelat.Mobile.Models.Response;
using Twkelat.Mobile.Services.IServices;
using Twkelat.Mobile.UserControl;

namespace Twkelat.Mobile.Pages;

public partial class SignupPage : ContentPage
{
    private readonly IUserService _userService;
    public SignupPage(IUserService userService)
    {
        InitializeComponent();
        _userService = userService;
    }
    public string Name
    {
        get
        {
            return nameTXT.Text;
        }
        set
        {
			nameTXT.Text = value;
        }
    }
    public string Email
    {
        get
        {
            return emailTXT.Text;
        }
        set
        {
			emailTXT.Text = value;
        }
    }
    public string Username
    {
        get
        {
            return usernameTXT.Text;
        }
        set
        {
            usernameTXT.Text = value;
        }
    }
    public string CivilId
    {
        get
        {
            return civilIdTXT.Text;
        }
        set
        {
            civilIdTXT.Text = value;
        }
    }
    public string Password
    {
        get
        {
            return passwordTXT.Text;
        }
        set
        {
            passwordTXT.Text = value;
        }
    }
    public string PasswordConfirmation
    {
        get
        {
            return passwordConfirmationTXT.Text;
        }
        set
        {
            passwordConfirmationTXT.Text = value;
        }
    }

    private async void Register_Clicked(object sender, EventArgs e)
    {
        if (nameValidator.IsNotValid)
        {
            await DisplayAlert("Error", "First Name is required.", "Ok");
            return;
        }
        if (emailValidator.IsNotValid)
        {
            await DisplayAlert("Error", "Last Name is required.", "Ok");
            return;
        }
        if (usernameValidator.IsNotValid)
        {
            await DisplayAlert("Error", "Username is required.", "Ok");
            return;
        }
        if (civilIdValidator.IsNotValid)
        {
            if (civilIdValidator.Errors == null)
            {
                await DisplayAlert("Error", "Civil Id is required.", "Ok");
                return;
            }
            foreach (var error in civilIdValidator?.Errors)
            {
                await DisplayAlert("Error", error?.ToString(), "Ok");
            }
            return;
        }
        if (passwordValidator.IsNotValid)
        {
            await DisplayAlert("Error", "Password is required.", "Ok");
            return;
        }
        if (!Password.Equals(PasswordConfirmation))
        {
            await DisplayAlert("Error", "Password is not equal to password confirmation  .", "Ok");
            return;
        }


        RegisterRequestModel model = new() { Username = Username,
            CivilId = CivilId, 
            Name = Name, 
            Email = Email,
            Password = Password,
        };
        var apiResponse = await _userService.Register<AuthModelResponse>(model);

        if (Preferences.ContainsKey(nameof(App.credData)))
        {
            Preferences.Remove(nameof(App.credData));
        }
        if (apiResponse.IsAuthenticated)
        {
            Preferences.Set(SD.SD.SessionToken, apiResponse.Token);
            Preferences.Set(nameof(App.credData), nameof(apiResponse));
            App.credData = apiResponse;
			App.currentCivilId = apiResponse.CivilId;

			AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }

    }

	private async void Cancel_Clicked(object sender, EventArgs e)
	{
		var navPage = new LoginPage(_userService);
		await Navigation.PushAsync(navPage);
	}
}