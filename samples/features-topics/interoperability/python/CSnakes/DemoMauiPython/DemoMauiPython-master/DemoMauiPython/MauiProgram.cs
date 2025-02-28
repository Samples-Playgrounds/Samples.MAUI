using CSnakes.Runtime;
using Microsoft.Extensions.Logging;

namespace DemoMauiPython
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            var home = OperatingSystem.IsMacOS() ?  Path.Join(Environment.CurrentDirectory, "Contents", "Resources", "Python") : Path.Join(Environment.CurrentDirectory, "Resources", "Raw", "Python");
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Montserrat-Medium.ttf", "RegularFont");
                    fonts.AddFont("Montserrat-SemiBold.ttf", "MediumFont");
                    fonts.AddFont("Montserrat-Bold.ttf", "BoldFont");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.WithPython()
                .WithHome(home)
                .FromNuGet("3.12.8")
                // .FromFolder("/Library/Frameworks/Python.Framework/Versions/3.12", "3.12")
                // .FromRedistributable()
                .WithVirtualEnvironment(Path.Join(home, ".venv"))
                .WithPipInstaller();

            return builder.Build();
        }
    }
}
