namespace Twkelat.Mobile.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    private async void ConirmBT_Clicked(object sender, EventArgs e)
    {
        string codeRequest = await DisplayPromptAsync("Secret Code", "Write you Secret Code");
        if (codeRequest == "123")
        {
            await DisplayAlert("Authenticated!", "Access granted", "OK");
            //change it in api
        }
        else
        {
            await DisplayAlert("Unauthenticated", "Access denied", "OK");
        }
    }
}