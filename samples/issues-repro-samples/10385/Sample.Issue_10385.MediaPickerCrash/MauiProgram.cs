using Microsoft.Extensions.Logging;

using CommunityToolkit.Maui;

namespace Sample.Issue_10385.MediaPickerCrash;

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
			})
			// used for
			//		Model View ViewModel MVVM
			//		MediaElement
            .UseMauiCommunityToolkit()
            ;

		#if DEBUG
		builder.Logging.AddDebug();
		#endif

		return builder.Build();
	}
}
