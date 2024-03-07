namespace Twkelat.Mobile.UserControl;

public partial class FlyoutHeaderControl : ContentView
{
	public FlyoutHeaderControl()
	{
        InitializeComponent();
        if (App.credData is not null)
        {
            lblUserName.Text = App.credData.Username;
        }
    }
}