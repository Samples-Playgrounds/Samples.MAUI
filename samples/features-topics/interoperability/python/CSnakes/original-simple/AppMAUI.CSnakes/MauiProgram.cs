using CSnakes.Runtime;
using Microsoft.Extensions.Logging;

namespace AppMAUI.CSnakes;

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

        builder.Services
            .WithPython()
            .WithPipInstaller()
            ;

        builder.Services.AddSingleton(sp => sp.GetRequiredService<IPythonEnvironment>().HelloWorld());


#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
