namespace AppMAUI.net80;

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

