using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;
using Twkelat.Mobile.Pages;
using Twkelat.Mobile.SD;
using Twkelat.Mobile.Services;
using Twkelat.Mobile.Services.IServices;
using Twkelat.Mobile.Repositories;
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
            builder.Services.AddSingleton<LoginWithImagePage>();
			builder.Services.AddSingleton<DocumentPage>();
            builder.Services.AddSingleton<SettingsPage>();
            builder.Services.AddSingleton<SignupPage>();
            builder.Services.AddSingleton<CreateDelegationPage>();
            builder.Services.AddSingleton<ConfirmDelegationPage>();
            builder.Services.AddSingleton<ViewDelegationPage>();


			// Services
			builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddScoped<IBaseService, BaseService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IDelegationService, DelegationService>();
            builder.Services.AddScoped<IDelegationRepository, DelegationRepository>();
            builder.Services.AddAutoMapper(typeof(MappingConfig));
            builder.Services.AddSingleton(typeof(IFingerprint), CrossFingerprint.Current);

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
