
// https://gist.github.com/myrup/43ee8038e0fd6ef4d31cbdd67449a997
// https://sentry.io/for/dotnet-maui/
// https://gist.github.com/mattjohnsonpint/7b385b7a2da7059c4a16562bc5ddb3b7
// https://stackoverflow.com/questions/5762526/how-can-i-make-something-that-catches-all-unhandled-exceptions-in-a-winforms-a
// https://learn.microsoft.com/en-us/aspnet/web-forms/overview/older-versions-getting-started/deploying-web-site-projects/processing-unhandled-exceptions-cs
// https://learn.microsoft.com/en-us/dotnet/api/system.appdomain.unhandledexception
// https://github.com/dotnet/maui/discussions/653
// https://peterno.wordpress.com/2015/04/15/unhandled-exception-handling-in-ios-and-android-with-xamarin/
// https://github.com/xamarin/xamarin-macios/issues/15252
public static class MauiGlobalExceptionHandler
{
#if WINDOWS
    private static Exception _lastFirstChanceException;
#endif

    // We'll route all unhandled exceptions through this one event.
    public static event UnhandledExceptionEventHandler UnhandledException;

    static MauiGlobalExceptionHandler()
    {
        /*
        to not catch exceptions when debugging, as this makes it easier to debug. It is somewhat of a hack, but for 
        that you can wrap the above code around with

         if (!AppDomain.CurrentDomain.FriendlyName.EndsWith("vshost.exe")) { ... }
        To prevent catching the exceptions when debugging.

        EDIT: An alternate way to check for your application running inside a debugger that feels cleaner than checking 
        a filename.
        if(!System.Diagnostics.Debugger.IsAttached) { ... }
        */



        // This is the normal event expected, and should still be used.
        // It will fire for exceptions from iOS and Mac Catalyst,
        // and for exceptions on background threads from WinUI 3.
        
        if(!System.Diagnostics.Debugger.IsAttached)
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, args) => 
            {
                UnhandledException?.Invoke(sender, args);
            };
            
            AppDomain.CurrentDomain.FirstChanceException += (sender, args) => 
            {
                UnhandledException?.Invoke(sender, new UnhandledExceptionEventArgs(args.Exception, false));
            };

            // Events fired by the TaskScheduler. That is calls like Task.Run(...)     
            TaskScheduler.UnobservedTaskException += (sender, args) => 
            {
                UnhandledException?.Invoke(sender, new UnhandledExceptionEventArgs(args.Exception, false));
            };

        }

#if IOS || MACCATALYST

        // For iOS and Mac Catalyst
        // Exceptions will flow through AppDomain.CurrentDomain.UnhandledException,
        // but we need to set UnwindNativeCode to get it to work correctly. 
        // 
        // See: https://github.com/xamarin/xamarin-macios/issues/15252
        
        if(!System.Diagnostics.Debugger.IsAttached)
        {
            ObjCRuntime.Runtime.MarshalManagedException += (_, args) =>
            {
                args.ExceptionMode = ObjCRuntime.MarshalManagedExceptionMode.UnwindNativeCode;
            };

            ObjCRuntime.Runtime.MarshalObjectiveCException += (_, args) =>
            {
                args.ExceptionMode = ObjCRuntime.MarshalObjectiveCExceptionMode.UnwindManagedCode;
            };
        }
#endif

#if ANDROID

        // For Android:
        // All exceptions will flow through Android.Runtime.AndroidEnvironment.UnhandledExceptionRaiser,
        // and NOT through AppDomain.CurrentDomain.UnhandledException

        if(!System.Diagnostics.Debugger.IsAttached)
        {
            Android.Runtime.AndroidEnvironment.UnhandledExceptionRaiser += (sender, args) =>
            {
                UnhandledException?.Invoke(sender, new UnhandledExceptionEventArgs(args.Exception, true));
            };
        }
#endif

#if WINDOWS

        // For WinUI 3:
        //
        // * Exceptions on background threads are caught by AppDomain.CurrentDomain.UnhandledException,
        //   not by Microsoft.UI.Xaml.Application.Current.UnhandledException
        //   See: https://github.com/microsoft/microsoft-ui-xaml/issues/5221
        //
        // * Exceptions caught by Microsoft.UI.Xaml.Application.Current.UnhandledException have details removed,
        //   but that can be worked around by saved by trapping first chance exceptions
        //   See: https://github.com/microsoft/microsoft-ui-xaml/issues/7160
        //

        if(!System.Diagnostics.Debugger.IsAttached)
        {
            AppDomain.CurrentDomain.FirstChanceException += (_, args) =>
            {
                _lastFirstChanceException = args.Exception;
            };

            Microsoft.UI.Xaml.Application.Current.UnhandledException += (sender, args) =>
            {
                var exception = args.Exception;

                if (exception.StackTrace is null)
                {
                    exception = _lastFirstChanceException;
                }

                UnhandledException?.Invoke(sender, new UnhandledExceptionEventArgs(exception, true));
            };

            // Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += new     
            ThreadExceptionEventHandler(ErrorHandlerForm.Form1_UIThreadException);
            // Set the unhandled exception mode to force all Windows Forms errors
            // to go through our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

        }
#endif
    }
}