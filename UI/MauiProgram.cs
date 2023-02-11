using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SokoEqCalculator.ViewModels;
using SokoEqCalculator.Views;

namespace SokoEqCalculator;

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
            })
            .RegisterRoutes()
            .RegisterAppServices();

#if DEBUG
		builder.Logging.AddDebug();
#endif


        return builder.Build();
	}

    private static MauiAppBuilder RegisterRoutes(this MauiAppBuilder builder)
    {
        builder.Services.AddSingletonWithShellRoute<MainPage, MainViewModel>("Home");
        builder.Services.AddSingletonWithShellRoute<SettingsView, SettingsViewModel>("Settings");
        builder.Services.AddSingletonWithShellRoute<AboutView, AboutViewModel>("About");
        return builder;
    }

    private static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
    {
        return builder;
    }
}
