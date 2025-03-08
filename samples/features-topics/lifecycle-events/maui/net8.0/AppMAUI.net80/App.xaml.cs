namespace AppMAUI.net80;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = 
                    // Shell
                    // new AppShell()    
                    // Navigation Direct (Non-Shell)
                    // new MainPage()
                    // Navigation with navigation Stack (Non-Shell)
                    new NavigationPage(new MainPage())
                    ;
	}
}
