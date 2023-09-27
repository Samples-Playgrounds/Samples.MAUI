namespace AppMAUI.FromTemplate;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        var app = App.Current as AppMAUI.FromTemplate.App;

        return;
    }

    private void picker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        Picker p = sender as Picker;
        string url = p.SelectedItem as string;

        //content_view_web_view

        return;
    }
}

