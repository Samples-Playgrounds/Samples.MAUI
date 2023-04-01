using Microsoft.Extensions.Logging;

namespace AppMAUI.Issue9234.AppActionIcons;

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
								fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
							}
						)
           .ConfigureEssentials
		   (
				essentials =>
			   {
				   //TODO: it's unclear whether icons must be in the Resources/Images folder or in the Platforms/{platform} folder
				   essentials
					   .AddAppAction
							(
								"notes",
								"Notes",
								"Notes",
								"si_ballot.png"	// will not be rendered
							)
					   .AddAppAction
							(
								"chat",
								"Chat",
								"Chat",
								"si_chat"		// rendered
							)
					   .OnAppAction(App.HandleAppActions);
			   }
			);

		#if DEBUG
		builder.Logging.AddDebug();
		#endif

		return builder.Build();
	}
}
