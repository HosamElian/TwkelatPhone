namespace Twkelat.Mobile.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		Shell.Current.GoToAsync(nameof(LoginPage));
	}
}