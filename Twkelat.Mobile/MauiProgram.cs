using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Twkelat.Mobile.Pages;
using Twkelat.Mobile.Repository;
using Twkelat.Mobile.Repository.IRepository;
using Twkelat.Mobile.ViewModels;

namespace Twkelat.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            
            // Pages
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<DocumentPage>();
            builder.Services.AddSingleton<SettingsPage>();
            builder.Services.AddSingleton<SignupPage>();

            // View Model
            builder.Services.AddSingleton<LoginPageViewModel>();

            // Services
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddSingleton<HttpClient>();
            
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
