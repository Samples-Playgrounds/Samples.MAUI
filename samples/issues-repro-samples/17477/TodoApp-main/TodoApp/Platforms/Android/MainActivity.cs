using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace TodoApp;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, NoHistory = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public override bool DispatchKeyEvent(KeyEvent e)
    {

        if (e.KeyCode == Keycode.Back)
        {
            // override button dispatch and disable back button functionality
            return true;
        }
        return base.DispatchKeyEvent(e);
    }
}
