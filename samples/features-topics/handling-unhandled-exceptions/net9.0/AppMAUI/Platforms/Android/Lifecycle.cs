using Android.App;
using Android.Content;
using Application = Microsoft.Maui.Controls.Application;

namespace AppMAUI;

// https://www.syncfusion.com/blogs/post/configuring-life-cycle-events-in-net-maui-apps
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
        throw new NotImplementedException();
    }

    public static
        void
                                        ApplicationConfigurationChanged
                                        (
                                            Android.App.Application application,
                                            Android.Content.Res.Configuration config
                                        )
    {
        throw new NotImplementedException();
    }
    
    public static
        void
                                        ApplicationCreate
                                        (
                                        )
    {
        throw new NotImplementedException();
    }
        

    public static
        void
                                        ApplicationCreating
                                        (
                                        )
    {
        throw new NotImplementedException();
    }
    
    public static
        void
                                        ApplicationLowMemory
                                        (
                                        )
    {
        throw new NotImplementedException();
    }
    
    public static
        void
                                        ApplicationTrimMemory
                                        (
                                        )
    {
        throw new NotImplementedException();
    }
    
    public static
        bool
                                        BackPressed
                                        (
                                        )
    {
        throw new NotImplementedException();
    }
    
    public static
        bool
                                        ConfigurationChanged
                                        (
                                        )
    {
        throw new NotImplementedException();
    }
    
    public static
        bool
                                        Create
                                        (
                                        )
    {
        throw new NotImplementedException();
    }
    
    public static
        bool
                                        Destroy
                                        (
                                        )
    {
        throw new NotImplementedException();
    }
        
    public static
        bool
                                        NewIntent
                                        (
                                        )
    {
        throw new NotImplementedException();
    }
    
    public static
        bool
                                        Pause
                                        (
                                        )
    {
        throw new NotImplementedException();
    }

    public static
        bool
                                        PostCreate
                                        (
                                        )
    {
        throw new NotImplementedException();
    }
    
    public static
        bool
                                        PostResume
                                        (
                                        )
    {
        throw new NotImplementedException();
    }
        
    public static
        bool
                                        RequestPermissionsResult
                                        (
                                        )
    {
        throw new NotImplementedException();
    }
    
    public static
        bool
                                        Restart
                                        (
                                        )
    {
        throw new NotImplementedException();
    }
        
    public static
        bool
                                        RestoreInstanceState
                                        (
                                        )
    {
        throw new NotImplementedException();
    }
    
    public static
        bool
                                        OnResume
                                        (
                                        )
    {
        throw new NotImplementedException();
    }
        
    public static
        bool
                                        SaveInstanceState
                                        (
                                        )
    {
        throw new NotImplementedException();
    }
    
    public static
        bool
                                        Start
                                        (
                                        )
    {
        throw new NotImplementedException();
    }
        
    
    public static
        bool
                                        OnStop
                                        (
                                        )
    {
        throw new NotImplementedException();
    }
}
