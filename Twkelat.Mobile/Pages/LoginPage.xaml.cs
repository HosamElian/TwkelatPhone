using Twkelat.Mobile.Models.Request;
using Twkelat.Mobile.Models.Response;
using Twkelat.Mobile.Services.IServices;
using Twkelat.Mobile.UserControl;

namespace Twkelat.Mobile.Pages;

public partial class LoginPage : ContentPage
{
    private readonly IUserService _userService;

    public LoginPage(IUserService userService)
    {
        InitializeComponent();
        _userService = userService;
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

    private async void Login(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");

        //if (civilIdValidator.IsNotValid)
        //{
        //    await DisplayAlert("Error", "Civil Id is required.", "Ok");
        //    return;
        //}
        //if (passwordValidator.IsNotValid)
        //{
        //    await DisplayAlert("Error", "Password is required.", "Ok");
        //    return;
        //}
        //var apiResponse = await _userService.Login<AuthModelResponse>(new LoginRequestModel() { CivilId = CivilId, Password = Password });

        //if (Preferences.ContainsKey(nameof(App.credData)))
        //{
        //    Preferences.Remove(nameof(App.credData));
        //}
        //if (apiResponse.IsAuthenticated)
        //{
        //    Preferences.Set(SD.SD.SessionToken, apiResponse.Token);
        //    Preferences.Set(nameof(App.credData), nameof(apiResponse));
        //    App.credData = apiResponse;

        //    AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
        //    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        //}

    }

    private async void SingupBT_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(SignupPage)}");
    }
}