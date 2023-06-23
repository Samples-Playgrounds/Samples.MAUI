using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Maps;
using Microsoft.Extensions.Logging;

namespace AppMAUI.Location;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiMaps()
			   .UseMauiCommunityToolkit()
			   // https://learn.microsoft.com/en-us/bingmaps/getting-started/bing-maps-dev-center-help/getting-a-bing-maps-key
               .UseMauiCommunityToolkitMaps("YOUR_KEY")
			.ConfigureFonts
                    (
                        fonts =>
                        {
                            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                        }
                    );

		builder.ConfigureMauiHandlers
        (
            handlers =>
                {
                    handlers.AddHandler
                                <
                                    Microsoft.Maui.Controls.Maps.Map,
                                    CustomMapHandler
                                >
                                    ();
                }
        );

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
