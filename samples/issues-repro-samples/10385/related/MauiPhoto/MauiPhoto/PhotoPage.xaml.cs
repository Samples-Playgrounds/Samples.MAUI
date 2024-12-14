namespace MauiPhoto;

public partial class PhotoPage : ContentPage
{
    public PhotoPage(PhotoViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }


}
