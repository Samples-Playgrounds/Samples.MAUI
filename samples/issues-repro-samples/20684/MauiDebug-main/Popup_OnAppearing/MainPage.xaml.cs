namespace Toolkit;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await ProgressPage.Show(delegate
		{
			for(int i = 0; i < 10; i++)
			{
				Thread.Sleep(500);
				MainThread.BeginInvokeOnMainThread(() => T.Text = i.ToString());
			}
		});
	}
}
