using TabbarHandlerIssue.Views;

namespace TabbarHandlerIssue;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new HomePage();
	}
}

