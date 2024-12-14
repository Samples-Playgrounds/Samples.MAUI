namespace AppMAUI.Issue9234.AppActionIcons;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    public static void HandleAppActions(AppAction appAction)
    {
        App.Current.Dispatcher.Dispatch
                                (
                                    async () =>
                                    {
                                        await Shell.Current.GoToAsync($"//{appAction.Id}");
                                    }
                                );
    }

}
