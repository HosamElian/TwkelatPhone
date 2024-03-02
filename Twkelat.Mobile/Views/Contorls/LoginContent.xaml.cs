namespace Twkelat.Mobile.Views.Contorls;

public partial class LoginContent : ContentView
{
    public event EventHandler<string> OnError;
    public event EventHandler<EventArgs> OnLogin;
    public event EventHandler<EventArgs> OnSignup;
    public LoginContent()
    {
        InitializeComponent();
    }
    public string Email
    {
        get
        {
            return entryEmail.Text;
        }
        set
        {
            entryEmail.Text = value;
        }
    }
    public string Password
    {
        get
        {
            return entryPassword.Text;
        }
        set
        {
            entryPassword.Text = value;
        }
    }
    private void btnLogin_Clicked(object sender, EventArgs e)
    {
        if (emailValidator.IsNotValid)
        {
            foreach (var error in emailValidator.Errors)
            {
                OnError?.Invoke(sender, error?.ToString());
            }
            return;
        }
        if (passwordValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Password must be at leaset 8 character.");
            return;
        }
        OnLogin.Invoke(sender, e);

    }

    private void btnSignup_Clicked(object sender, EventArgs e)
    {
        OnSignup.Invoke(sender, e);
    }
}