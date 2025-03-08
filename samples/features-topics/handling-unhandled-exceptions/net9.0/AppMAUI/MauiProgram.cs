using Microsoft.Extensions.Logging;

using Microsoft.Maui.LifecycleEvents;

namespace AppMAUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
     builder.ConfigureLifecycleEvents
                (
                    AppLifecycle => 
                    {
                    }
                );

        
#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

    private static void EnteredForeground()
    {
        throw new NotImplementedException();
    }
}
