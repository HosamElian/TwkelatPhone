using Twkelat.Mobile.ViewModels;

namespace Twkelat.Mobile.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel loginPageViewModel)
	{
		InitializeComponent();
        this.BindingContext = loginPageViewModel;
	}

    //private void btnLogin_Clicked(object sender, EventArgs e)
    //{
    //    Shell.Current.GoToAsync($"{nameof(HomePage)}");

    //}

    //private void btnSignup_Clicked(object sender, EventArgs e)
    //{
    //    Shell.Current.GoToAsync($"{nameof(SignupPage)}");

    //}

    //private void loginCtrl_OnError(object sender, string e)
    //{
    //    DisplayAlert("Error", e, "Ok");
    //}


}