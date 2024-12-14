namespace ANR;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
	}

	protected override async void OnNavigating(ShellNavigatingEventArgs args)
	{
		base.OnNavigating(args);

		ShellNavigatingDeferral token = args.GetDeferral();

		var result = await DisplayActionSheet("Navigate?", "Cancel", "Yes", "No");
		if(result != "Yes")
		{
			args.Cancel();
		}
		token.Complete();
	}
}
