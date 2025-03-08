using Android.App;
using Android.Content;
using Application = Microsoft.Maui.Controls.Application;

namespace AppMAUI;

/*
    https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/app-lifecycle
    https://www.syncfusion.com/blogs/post/configuring-life-cycle-events-in-net-maui-apps
*/
/*
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
                                                              (activity) => Lifecycle.OnActivityResult()
                                                          )
                                          );
                          AppLifecycle.AddAndroid
                                          (
                                              android => 
                                              android.OnApplicationConfigurationChanged
                                                          (
                                                              (activity) => Lifecycle.ApplicationConfigurationChanged()
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
                                              android.OnApplicationLowMemory
                                                          (
                                                              (app) => Lifecycle.ApplicationLowMemory()
                                                          )
                                          );
                          AppLifecycle.AddAndroid
                                          (
                                              android => 
                                              android.OnApplicationTrimMemory
                                                          (
                                                              (activity) => Lifecycle.ApplicationTrimMemory()
                                                          )
                                          );
                          AppLifecycle.AddAndroid
                                          (
                                              android => 
                                              android.OnBackPressed
                                                          (
                                                              (activity) => Lifecycle.BackPressed()
                                                          )
                                          );
                          AppLifecycle.AddAndroid
                                          (
                                              android => 
                                              android.OnCreate
                                                          (
                                                              (activity) => Lifecycle.Create()
                                                          )
                                          );
                          AppLifecycle.AddAndroid
                                          (
                                              android => 
                                              android.OnDestroy
                                                          (
                                                              (activity) => Lifecycle.Destroy()
                                                          )
                                          );
                          AppLifecycle.AddAndroid
                                          (
                                              android => 
                                              android.OnNewIntent
                                                          (
                                                              (activity) => Lifecycle.NewIntent()
                                                          )
                                          );
                          AppLifecycle.AddAndroid
                                          (
                                              android => 
                                              android.OnPause
                                                          (
                                                              (activity) => Lifecycle.Pause()
                                                          )
                                          );
                          AppLifecycle.AddAndroid
                                          (
                                              android => 
                                              android.OnOnPostCreate
                                                          (
                                                              (activity) => Lifecycle.PostCreate()
                                                          )
                                          );
                          AppLifecycle.AddAndroid
                                          (
                                              android => 
                                              android.OnPostResume
                                                          (
                                                              (activity) => Lifecycle.PostResume()
                                                          )
                                          );
                          AppLifecycle.AddAndroid
                                          (
                                              android => 
                                              android.OnRequestPermissionsResult
                                                          (
                                                              (activity) => Lifecycle.RequestPermissionsResult()
                                                          )
                                          );
                          AppLifecycle.AddAndroid
                                          (
                                              android => 
                                              android.OnRestart
                                                          (
                                                              (activity) => Lifecycle.Restart()
                                                          )
                                          );
                          AppLifecycle.AddAndroid
                                          (
                                              android => 
                                              android.OnRestoreInstanceState
                                                          (
                                                              (activity) => Lifecycle.RestoreInstanceState()
                                                          )
                                          );
                          AppLifecycle.AddAndroid
                                          (
                                              android => 
                                              android.OnResume
                                                          (
                                                              (activity) => Lifecycle.Resume()
                                                          )
                                          );
                          AppLifecycle.AddAndroid
                                          (
                                              android => 
                                              android.OnSaveInstanceState
                                                          (
                                                              (activity) => Lifecycle.SaveInstanceState()
                                                          )
                                          );
                          AppLifecycle.AddAndroid
                                          (
                                              android => 
                                              android.OnStart
                                                          (
                                                              (activity) => Lifecycle.Start()
                                                          )
                                          );
                          AppLifecycle.AddAndroid
                                          (
                                              android => 
                                              android.OnStop
                                                          (
                                                              (activity) => Lifecycle.Stop()
                                                          )
                                          );
                      #endif
              );                      
 */
public partial class
                                        Lifecycle
                                        :
                                        ITrace
                                        //ITraceNotFound
{
    public static 
        void
                                        OnActivityResult
                                        (
                                            Activity activity,
                                            int code,
                                            Result resultCode,
                                            Intent data
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return;
    }

    public static
        void
                                        ApplicationConfigurationChanged
                                        (
                                            Android.App.Application application,
                                            Android.Content.Res.Configuration config
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return;
    }
    
    public static
        void
                                        ApplicationCreate
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return;
    }
        

    public static
        void
                                        ApplicationCreating
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return;
    }
    
    public static
        void
                                        ApplicationLowMemory
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return;
    }
    
    public static
        void
                                        ApplicationTrimMemory
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return;
    }
    
    public static
        bool
                                        BackPressed
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return true;
    }
    
    public static
        bool
                                        ConfigurationChanged
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return true;
    }
    
    public static
        bool
                                        Create
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return true;
    }
    
    public static
        bool
                                        Destroy
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return true;
    }
        
    public static
        bool
                                        NewIntent
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return true;
    }
    
    public static
        bool
                                        Pause
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return true;
    }

    public static
        bool
                                        PostCreate
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return true;
    }
    
    public static
        bool
                                        PostResume
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return true;
    }
        
    public static
        bool
                                        RequestPermissionsResult
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return true;
    }
    
    public static
        bool
                                        Restart
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return true;
    }
        
    public static
        bool
                                        RestoreInstanceState
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return true;
    }
    
    public static
        bool
                                        OnResume
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return true;
    }
        
    public static
        bool
                                        SaveInstanceState
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return true;
    }
    
    public static
        bool
                                        Start
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return true;
    }
        
    
    public static
        bool
                                        OnStop
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return true;
    }

    public
        static
        string
                                        TraceWriteLine
                                        (
                                            string message = "",
                                            [System.Runtime.CompilerServices.CallerMemberName]
                                            string member_name = "",
                                            [System.Runtime.CompilerServices.CallerFilePath]
                                            string source_file_path = "",
                                            [System.Runtime.CompilerServices.CallerLineNumber]
                                            int source_line_number = 0
                                        )
    {
        using ( Cysharp.Text.Utf16ValueStringBuilder sb = Cysharp.Text.ZString.CreateStringBuilder() )
        {
            sb.Append("message : ");
            sb.Append(message);
            sb.AppendLine();
            sb.Append("member_name : ");
            sb.Append(member_name);
            sb.AppendLine();
            sb.Append("source_file_path : ");
            sb.Append(source_file_path);
            sb.AppendLine();
            sb.Append("source_line_number : ");
            sb.Append(source_line_number);
            sb.AppendLine();

            string retval = sb.ToString();
            System.Diagnostics.Trace.WriteLine(retval);
            
            return retval;
        }
    }
}
