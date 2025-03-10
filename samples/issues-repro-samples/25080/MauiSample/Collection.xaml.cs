namespace MauiSample;

public partial class Collection : ContentPage
{
	public Collection()
	{
		InitializeComponent();
        BindingContext = new MainPageViewModel();
    }
}