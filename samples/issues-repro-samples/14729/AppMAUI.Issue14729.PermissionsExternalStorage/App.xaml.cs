namespace AppMAUI.Issue14729.PermissionsExternalStorage;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
