using Android.App;
using Android.Content.PM;
using Android.OS;

namespace AppMAUI.BlazorHybrid.net90;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public override bool DispatchKeyEvent(Android.Views.KeyEvent? e)
    {
        System.Diagnostics.Trace.WriteLine("This line isn't executed with Microsoft.Maui version 9.x.x, it is executed with version 8.0.100");

        return base.DispatchKeyEvent(e);
    }
    
    
}
