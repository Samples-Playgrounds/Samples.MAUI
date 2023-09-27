using Microsoft.Extensions.Logging;

namespace AppMAUI.FromTemplate;

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
            .ConfigureMauiHandlers
                        (
                            (handlers) =>
                            {
                                #if ANDROID
                                handlers.AddHandler
                                                (
                                                    typeof(HolisticWare.XamarinForms.WebView.PDF.Google.WebView),
                                                    typeof(HolisticWare.XamarinForms.WebView.PDF.Google.WebViewRenderer)
                                                );
                                handlers.AddHandler
                                                (
                                                    typeof(HolisticWare.XamarinForms.WebView.PDF.Javascript.WebView),
                                                    typeof(HolisticWare.XamarinForms.WebView.PDF.Javascript.WebViewRenderer)
                                                );
                                #elif IOS
                                handlers.AddHandler
                                                (
                                                    typeof(HolisticWare.XamarinForms.WebView.PDF.Google.WebView),
                                                    typeof(HolisticWare.XamarinForms.WebView.PDF.Google.WebViewRenderer)
                                                );
                                handlers.AddHandler
                                                (
                                                    typeof(HolisticWare.XamarinForms.WebView.PDF.Javascript.WebView),
                                                    typeof(HolisticWare.XamarinForms.WebView.PDF.Javascript.WebViewRenderer)
                                                );
                                #endif
                            }
                        )
                        ; // builder

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}

