using CSnakes.Runtime;
using Microsoft.Extensions.Logging;

namespace CSnakesTest {
	public static class MauiProgram {
		public static MauiApp CreateMauiApp() {
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts => {
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

			string pythonVersionWindows = "3.13.0";
			string pythonVersionMacOS = Environment.GetEnvironmentVariable("PYTHON_VERSION") ?? "3.13";
			string pythonVersionLinux = Environment.GetEnvironmentVariable("PYTHON_VERSION") ?? "3.13";
			string condaBinPath = Environment.GetEnvironmentVariable("CONDA_BIN_PATH") ?? "\"C:\\ProgramData\\Anaconda\\Scripts\\conda.exe\"";

			string home = Path.Join(Environment.CurrentDirectory, "Python");

			builder.Services.WithPython()
				.FromNuGet(pythonVersionWindows)
				.FromMacOSInstallerLocator(pythonVersionMacOS)
				.FromEnvironmentVariable("Python3_ROOT_DIR", pythonVersionLinux)
				.WithHome(home)
				.FromConda(condaBinPath)
				.WithCondaEnvironment("csnakes")
				.WithPipInstaller();
			builder.Services.AddSingleton(sp => sp.GetRequiredService<IPythonEnvironment>().HelloWorld());

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
