namespace Sample.Issue_10385.MediaPickerCrash;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute("mediapickerdemo", typeof(Views.MediaPickerDemos));

    }
}
