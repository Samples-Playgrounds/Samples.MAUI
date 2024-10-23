using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;

namespace AppMAUI.mauiapp.net9._0;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
public class MainActivity : MauiAppCompatActivity
{    
    public override bool OnKeyUp([GeneratedEnum] Android.Views.Keycode keyCode, KeyEvent e)
    {
        bool wasHandled = false; //PlatformService.HandleOnKeyUp(keyCode, e);
        if (!wasHandled)
            return base.OnKeyUp(keyCode, e);
        else
            return true;
    }        

}
