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
                        #if ANDROID
                            AppLifecycle.AddAndroid
                                            (
                                                android => 
                                                android.OnActivityResult
                                                            (
                                                                (activity, code, result_code, data) 
                                                                => 
                                                                Lifecycle.OnActivityResult(activity, code, result_code, data)
                                                            )
                                            );
                            AppLifecycle.AddAndroid
                                            (
                                                android => 
                                                android.OnApplicationConfigurationChanged
                                                            (
                                                                (application, config) 
                                                                => 
                                                                Lifecycle.ApplicationConfigurationChanged(application, config)
                                                            )
                                            );
                            AppLifecycle.AddAndroid
                                            (
                                                android => 
                                                android.OnApplicationCreate
                                                            (
                                                                (activity) => Lifecycle.ApplicationCreate()
                                                            )
                                            );
                            AppLifecycle.AddAndroid
                                            (
                                                android => 
                                                android.OnApplicationCreating
                                                            (
                                                                (activity) => Lifecycle.ApplicationCreating()
                                                            )
                                            );
                            AppLifecycle.AddAndroid
                                            (
                                                android => 
                                                android.OnApplicationConfigurationChanged
                                                            (
                                                                (application, config)
                                                                => 
                                                                Lifecycle.ApplicationConfigurationChanged(application, config)
                                                            )
                                            );
                        #endif
                        #if IOS
                        AppLifecycle.AddiOS
                                            (
                                                ios => 
                                                ios.WillEnterForeground((app) => EnteredForeground())
                                            );
                        #endif
                        #if WINDOWS
                        AppLifecycle.AddWindows
                                            (
                                                windows =>
                                                windows.OnNativeMessage
                                                            (
                                                                (app, args) => 
                                                                {
                                                                    app.ExtendsContentIntoTitleBar = false;
                                                                }
                                                            )
                                            );
                        #endif

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
