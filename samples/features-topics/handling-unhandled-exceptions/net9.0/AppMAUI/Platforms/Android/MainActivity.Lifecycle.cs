using Android.App;
using Android.Content.PM;
using Android.OS;

namespace AppMAUI;
public partial class
                                        MainActivity
{
    protected override 
        void
                                        OnCreate
                                        (
                                            Bundle? savedInstanceState
                                        )
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        // SetContentView(Resource.Layout.activity_main);
    }    
    
    protected override 
        void
                                        OnStart
                                        (
                                        )
    {
        base.OnStart();
    }
    
    protected override 
        void
                                        OnResume
                                        (
                                        )
    {
        base.OnResume();
    }
    
    protected override 
        void
                                        OnPause
                                        (
                                        )
    {
        base.OnPause();
    }
    
    protected override 
        void
                                        OnStop
                                        (
                                        )
    {
        base.OnStop();
    }
    
    protected override 
        void
                                        OnDestroy
                                        (
                                        )
    {
        base.OnDestroy();
    }
    
    protected override 
        void
                                        OnRestart
                                        (
                                        )
    {
        base.OnRestart();
    }
    
    protected override 
        void
                                        OnSaveInstanceState
                                        (
                                            Bundle outState
                                        )
    {
        base.OnSaveInstanceState(outState);
    }
    
    protected override 
        void
                                        OnRestoreInstanceState
                                        (
                                            Bundle savedInstanceState
                                        )
    {
        base.OnRestoreInstanceState(savedInstanceState);
    }
    
    protected override 
        void
                                        OnNewIntent
                                        (
                                            Android.Content.Intent? intent
                                        )
    {
        base.OnNewIntent(intent);
    }
    
    protected override 
        void
                                        OnActivityResult
                                        (
                                            int requestCode,
                                            Result resultCode,
                                            Android.Content.Intent? data
                                        )
    {
        base.OnActivityResult(requestCode, resultCode, data);
    }

    public override 
        void
                                        OnRequestPermissionsResult
                                        (
                                            int requestCode,
                                            string[] permissions,
                                            Permission[] grantResults
                                        )
    {
        if ()
        base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    }

    public override 
        void
                                        OnBackPressed
                                        (
                                        )
    {
        #pragma warning disable CS0612 // is obsolete
        base.OnBackPressed();
        #pragma warning restore CS0612 // is obsolete
    }

    public override 
        void
                                        OnConfigurationChanged
                                        (
                                            Android.Content.Res.Configuration newConfig
                                        )
    {
        base.OnConfigurationChanged(newConfig);
    }
    
    protected override 
        void
                                        OnUserLeaveHint
                                        (
                                        )
    {
        base.OnUserLeaveHint();
    }
    
}
