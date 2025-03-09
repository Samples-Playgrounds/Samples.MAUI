namespace testmedia;

public partial class PageOne : ContentPage
{
	public PageOne()
	{
		InitializeComponent();
	}

    private async void OnBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PageTwo());
    }
}
