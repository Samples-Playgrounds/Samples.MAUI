namespace MauiSample;

public partial class SingleCollectionView : ContentPage
{
	public SingleCollectionView()
	{
		InitializeComponent();
        BindingContext = new MainPageViewModel();
    }
}