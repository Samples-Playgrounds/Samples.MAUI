namespace AppMAUI.FromTemplate;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnClicked_button_web_view(object sender, EventArgs e)
    {
        string url = entry_url.Text;

        Navigation.PushAsync(new ContentPageWebView());

        return;
    }

    private void OnClicked_button_web_view_pdf(object sender, EventArgs e)
    {
        string url = entry_url.Text;

        Navigation.PushAsync(new ContentPageWebView());

        return;
    }

    private void OnClicked_button_web_view_custom(object sender, EventArgs e)
    {
        string url = entry_url.Text;

        Navigation.PushAsync(new ContentPageWebView());

        return;
    }
}


