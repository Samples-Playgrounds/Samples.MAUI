namespace AppMAUI.net90;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnBtnClicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new PageOne());
    }
}

