namespace MauiPhoto;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Shell.SetTabBarIsVisible(this, false);


        Routing.RegisterRoute(nameof(OtherPage), typeof(OtherPage));
        Routing.RegisterRoute(nameof(StartPage), typeof(StartPage));
        Routing.RegisterRoute(nameof(PhotoPage), typeof(PhotoPage));
    }

    protected  override void OnAppearing()
    {
        base.OnAppearing();
        menuShell.CurrentItem = start;
    }
}
