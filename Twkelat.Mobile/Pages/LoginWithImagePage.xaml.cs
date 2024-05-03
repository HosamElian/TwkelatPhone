
using Twkelat.Mobile.Services.IServices;

namespace Twkelat.Mobile.Pages;

public partial class LoginWithImagePage : ContentPage
{
	private readonly IUserService _userService;

	public LoginWithImagePage( IUserService userService)
	{
		_userService = userService;
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		var navPage = new LoginPage(_userService);
		await Navigation.PushAsync(navPage);
	}
}