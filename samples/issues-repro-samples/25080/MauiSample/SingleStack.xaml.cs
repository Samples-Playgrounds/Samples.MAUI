namespace MauiSample;

public partial class SingleStack : ContentPage
{
	public SingleStack()
	{
		InitializeComponent();
        BindingContext = new MainPageViewModel();
    }
}