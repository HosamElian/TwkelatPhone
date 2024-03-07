using Twkelat.Mobile.Models;

namespace Twkelat.Mobile
{
    public partial class App : Application
    {
        public static AuthModelResponse credData;
        public static string BaseURL = "http://172.29.144.1:5204/api/";
        public static string LoginController = "Auth/";
        public static string LoginEndPoint = "login";

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
