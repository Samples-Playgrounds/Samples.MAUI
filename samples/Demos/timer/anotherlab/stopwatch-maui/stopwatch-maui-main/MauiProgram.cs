using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;
using CommunityToolkit.Maui;

namespace StopwatchMaui
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts
                (
                    fonts =>
                    {
                        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                        fonts.AddFont("digital-7 (mono).ttf", "DigitalMono");
                        fonts.AddFont("fa-solid-900.ttf", "FontAwesome");
                    }
                )
                .UseMauiCommunityToolkit()
                ;

			return builder.Build();
		}
	}
}
