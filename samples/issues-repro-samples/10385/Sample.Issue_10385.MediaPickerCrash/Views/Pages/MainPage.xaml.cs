namespace Sample.Issue_10385.MediaPickerCrash;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void button_page_media_picker_Clicked(object sender, EventArgs e)
	{
        // Shell.Current.GoToAsync("//mediapickerdemo");
        Navigation.PushAsync(new Views.MediaPickerDemos());

        return;
	}
}

