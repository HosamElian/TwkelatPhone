namespace Twkelat.Mobile.Pages;

public partial class ConfirmDelegationPage : ContentPage
{
	public ConfirmDelegationPage()
	{
		InitializeComponent();
        LoadedDelegationMSG();
	}

    private void LoadedDelegationMSG()
    {
        entryConfirmText.Text = "By Sign on this asfvfbnghbbdf Please Sign to confirm";
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        // send model to check and save
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}