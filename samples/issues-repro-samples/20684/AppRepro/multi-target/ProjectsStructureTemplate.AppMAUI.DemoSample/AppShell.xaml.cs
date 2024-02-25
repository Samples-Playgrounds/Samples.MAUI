namespace AppMAUI.DemoSample;

public partial class 
										AppShell
										:
										Shell
{
	public 
										AppShell
										(											
										)
	{
		InitializeComponent();

		Routing.RegisterRoute
					(
						"person", 
						typeof(UserInterface.Person.View.Page)
					);
		Routing.RegisterRoute
					(
						"datetime", 
						typeof(UserInterface.DateTime.View.Page)
					);

		return;
	}
}
