using Twkelat.Mobile.Models;

namespace Twkelat.Mobile
{
    public partial class App : Application
    {
        public static AuthModelResponse credData;


        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
