namespace ThreeTabsCrash;

public partial class MyTabbedPage : TabbedPage
{
    public MyTabbedPage()
    {
        InitializeComponent();
    }

    private void OnMainPageClicked( object sender, EventArgs e )
    {
        App.Current.MainPage.Navigation.PopAsync(false);
        App.Current.MainPage.Navigation.PopAsync(false);
    }
}
