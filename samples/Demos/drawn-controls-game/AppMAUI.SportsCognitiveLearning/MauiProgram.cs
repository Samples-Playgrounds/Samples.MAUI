﻿using Microsoft.Extensions.Logging;

using Orbit.Engine;

namespace AppMAUI.SportsCognitiveLearning;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        MauiAppBuilder builder = MauiApp.CreateBuilder();
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
            .UseOrbitEngine()
            ;

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
