namespace Toolkit;

public partial class SecPage : ContentPage
{
	public SecPage()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await ProgressPage.Show();
	}
}