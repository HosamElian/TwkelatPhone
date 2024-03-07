using Twkelat.Mobile.Pages;
using Twkelat.Mobile.ViewModels;

namespace Twkelat.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            this.BindingContext = new AppShellViewModel();
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        }

    }
}
