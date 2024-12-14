namespace Picker;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnBtnDisablePicker(object sender, EventArgs e)
	{
		picker.IsEnabled = !picker.IsEnabled;
	}

	private async void OnBtnPush(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new MainPage());
	}
}

