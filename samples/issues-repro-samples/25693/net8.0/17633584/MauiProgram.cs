using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace MauiApp14
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                                .ConfigureLifecycleEvents(events =>
                                {
#if ANDROID
                                    events.AddAndroid(android => android
                                    .OnCreate((activity, bundle) =>
                                    {
                                        AndroidX.Core.SplashScreen.SplashScreen.InstallSplashScreen(activity);
                                    }));
#endif
                                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
