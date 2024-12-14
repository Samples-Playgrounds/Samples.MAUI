namespace AppMAUI.FromTemplate;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }


    public string Url
    {
        get;
        set;
    }
}

