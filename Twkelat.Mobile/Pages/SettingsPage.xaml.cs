using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Twkelat.Mobile.Models.Request;
using Twkelat.Mobile.Models.Response;
using Twkelat.Mobile.Services.IServices;

namespace Twkelat.Mobile.Pages;

public partial class SettingsPage : ContentPage
{
	private readonly IUserService _userService;

	public SettingsPage(IUserService userService)
	{
		InitializeComponent();
		_userService = userService;
	}

    private async void ConirmBT_Clicked(object sender, EventArgs e)
    {
		string codeRequest = await DisplayPromptAsync("Authentication", "Write your old Password", maxLength:10);
        if (String.IsNullOrWhiteSpace(codeRequest)) return;

		var userWithCode = new ChangeCodeRequestDTO 
		{ 
			CivilId = App.currentCivilId, 
			OldCode = codeRequest,
			NewCode = newKeyTXT.Text,
		};
		var request = await _userService.ChangeCode<APIResponse>(userWithCode);
		if (request.IsSuccess)
		{
			await Toast.Make("Confirmed", ToastDuration.Short).Show();
			newKeyTXT.Text = "";
		}
		else
		{
			await Toast.Make("Wrong Code", ToastDuration.Short).Show();

		}
        
    }
}