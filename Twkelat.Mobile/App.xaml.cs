using Plugin.Fingerprint;
using Twkelat.Mobile.Models.Request;
using Twkelat.Mobile.Models.Response;
using Twkelat.Mobile.Pages;

namespace Twkelat.Mobile
{
    public partial class App : Application
    {
        public static AuthModelResponse credData;
        public static CreateBlockRequest createBlockRequest;
        public static string currentCivilId = string.Empty;


        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

        }
    }
}
