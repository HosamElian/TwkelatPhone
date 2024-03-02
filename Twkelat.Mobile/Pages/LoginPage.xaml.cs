namespace Twkelat.Mobile.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    private void btnLogin_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"{nameof(HomePage)}");

    }

    private void btnSignup_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"{nameof(SignupPage)}");

    }

    private void loginCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "Ok");
    }
}