using Newtonsoft.Json;
using Twkelat.Mobile.Models;
using Twkelat.Mobile.Repository.IRepository;
using Twkelat.Mobile.UserControl;
using Twkelat.Mobile.ViewModels;

namespace Twkelat.Mobile.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage(IUserRepository userRepository)
    {
        InitializeComponent();
        _userRepository = userRepository;

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

    private readonly IUserRepository _userRepository;

    private async void Login(object sender, EventArgs e)
    {
        if (emailValidator.IsNotValid)
        {
            foreach (var error in emailValidator.Errors)
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
        LoginModel model = new() { Email = Email, Password = Password };
        var resultJson = await _userRepository.Login(model);

        if (Preferences.ContainsKey(nameof(App.credData)))
        {
            Preferences.Remove(nameof(App.credData));
        }
        if (resultJson != null)
        {
            var data = JsonConvert.SerializeObject(resultJson);
            Preferences.Set(nameof(App.credData), data);
            App.credData = resultJson;
            AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }

    }

    private async void SingupBT_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(SignupPage)}");
    }
}