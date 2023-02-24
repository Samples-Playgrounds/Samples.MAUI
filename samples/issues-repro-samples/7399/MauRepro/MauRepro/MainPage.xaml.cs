namespace MauRepro;

public partial class MainPage : ContentPage
{
    bool is_loadecd;
    WebViewSource web_view_source = null;

    public MainPage()
    {
        InitializeComponent();

        is_loadecd = web_view.IsLoaded;
        web_view_source = web_view.Source;

        web_view.Navigated += Web_view_Navigated;
        web_view.Navigating += Web_view_Navigating;

        return;
    }

    private void Web_view_Navigating(object sender, WebNavigatingEventArgs e)
    {
        is_loadecd = web_view.IsLoaded;
        web_view_source = web_view.Source;

        return;
    }

    private void Web_view_Navigated(object sender, WebNavigatedEventArgs e)
    {
        is_loadecd = web_view.IsLoaded;
        web_view_source = web_view.Source;

        return;
    }
}

