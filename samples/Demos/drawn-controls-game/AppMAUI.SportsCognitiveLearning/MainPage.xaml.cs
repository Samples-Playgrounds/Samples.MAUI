namespace AppMAUI.SportsCognitiveLearning;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

        return;
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("PageSportsCognitiveLearningScene");

        return;
	}
}

