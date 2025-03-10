namespace MauiSample;

public partial class Stack : ContentPage
{
	public Stack()
	{
		InitializeComponent();
        BindingContext = new MainPageViewModel();
    }
}