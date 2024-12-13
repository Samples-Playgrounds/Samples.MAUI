using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif

		System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();

		using var stream1 = assembly.GetManifestResourceStream("AppMAUI.appsettings.1.json");
		if (stream1 is not null)
		{
			Console.WriteLine("Stream appsettings.1.json opened");
		}
		var config1 = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
																				.AddJsonStream(stream1)
																				.Build();
		builder.Configuration.AddConfiguration(config1);

        Console.WriteLine($"{builder.Configuration["Settings:KeyOne"]}");
        Console.WriteLine($"{builder.Configuration["Settings:KeyTwo"]}");
        Console.WriteLine($"{builder.Configuration["Settings:KeyThree:Message"]}");

        using var stream2 = assembly.GetManifestResourceStream("AppMAUI.appsettings.2.json");
		if (stream2 is not null)
		{
			Console.WriteLine("Stream appsettings.2.json opened");
		}
		var config2 = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
																				.AddJsonStream(stream2)
																				.Build();
		builder.Configuration.AddConfiguration(config2);

        Console.WriteLine($"{builder.Configuration["Settings:KeyOne"]}");
        Console.WriteLine($"{builder.Configuration["Settings:KeyTwo"]}");
        Console.WriteLine($"{builder.Configuration["Settings:KeyThree:Message"]}");

		return builder.Build();
	}
}
