namespace AppMAUI.net90;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window
                        (
                            // https://www.mauicestclair.fr/en/posts/tips/maui-app-with-no-shell/
                            // https://stackoverflow.com/questions/76247721/how-to-create-a-non-shell-app-in-net-maui
                            // Shell
                            // new AppShell()    
                            // Navigation Direct (Non-Shell)
                            // new MainPage()
                            // Navigation with navigation Stack (Non-Shell)
                            new NavigationPage(new MainPage())
                        );
	}
}
