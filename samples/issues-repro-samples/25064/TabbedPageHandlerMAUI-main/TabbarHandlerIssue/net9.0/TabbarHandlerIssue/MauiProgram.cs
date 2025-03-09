using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace TabbarHandlerIssue;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCompatibility()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

			builder.ConfigureMauiHandlers(handlers =>
            {
#if __ANDROID__
                handlers.AddHandler(typeof(Foundation.TabbedPage), typeof(Platforms.Android.TabbedPageHandler));
#elif IOS
				handlers.AddHandler(typeof(Foundation.TabbedPage), typeof(Platforms.iOS.TabbedPageHandler));
#endif

            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

