namespace CleanApp.Pages;

public partial class BasePage : ContentPage
{
	public BasePage()
	{
		InitializeComponent();
        IconImageSource = ImageSource.FromFile("Title_Logo.png");
	}
}