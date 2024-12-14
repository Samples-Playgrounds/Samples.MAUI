using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace MauiBug_DeepLinkCrash;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
[IntentFilter(new[] { Intent.ActionView },
          Categories = new[] {
              Intent.CategoryDefault,
              Intent.CategoryBrowsable
          },
          DataSchemes = new string[] { "http", "https" },
          DataHost = "www.deeplink.com",
          DataPaths = new string[] { "/player.php", "/tournaments/view.php" },
          AutoVerify = true)]
public class MainActivity : MauiAppCompatActivity
{
}
