using Newtonsoft.Json;
using Twkelat.Mobile.Models;
using Twkelat.Mobile.Repository.IRepository;
using Twkelat.Mobile.UserControl;

namespace Twkelat.Mobile.Pages;

public partial class SignupPage : ContentPage
{
	public SignupPage(IUserRepository userRepository)
	{
		InitializeComponent();
        _userRepository = userRepository;

    }
    public string FirstName
    {
        get
        {
            return firstNameTXT.Text;
        }
        set
        {
            firstNameTXT.Text = value;
        }
    }
    public string LastName
    {
        get
        {
            return lastNameTXT.Text;
        }
        set
        {
            lastNameTXT.Text = value;
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


    private readonly IUserRepository _userRepository;

    private async void Register_Clicked(object sender, EventArgs e)
    {
        if (firstNameValidator.IsNotValid)
        {
            await DisplayAlert("Error", "First Name is required.", "Ok");
            return;
        }
        if (lastNameValidator.IsNotValid)
        {
            await DisplayAlert("Error", "Last Name is required.", "Ok");
            return;
        }
        if (usernameValidator.IsNotValid)
        {
                await DisplayAlert("Error", "Username is required.", "Ok");
            return;
        }
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
        if (!Password.Equals(PasswordConfirmation))
        {
            await DisplayAlert("Error", "Password is not equal to password confirmation  .", "Ok");
            return;
        }
     
        
        RegisterModel model = new() { Username = Username, Email = Email, Password = Password };
        var resultJson = await _userRepository.Register(model);

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

   
}