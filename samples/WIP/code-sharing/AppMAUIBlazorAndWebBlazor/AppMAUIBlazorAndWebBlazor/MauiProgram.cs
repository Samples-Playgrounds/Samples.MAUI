﻿using Microsoft.Extensions.Logging;
using Microsoft.FluentUI.AspNetCore.Components;
using AppMAUIBlazorAndWebBlazor.Shared.Services;
using AppMAUIBlazorAndWebBlazor.Services;

namespace AppMAUIBlazorAndWebBlazor;

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
            });

        // Add device-specific services used by the AppMAUIBlazorAndWebBlazor.Shared project
        builder.Services.AddSingleton<IFormFactor, FormFactor>();

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddFluentUIComponents();builder.Services.AddFluentUIComponents();


#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
