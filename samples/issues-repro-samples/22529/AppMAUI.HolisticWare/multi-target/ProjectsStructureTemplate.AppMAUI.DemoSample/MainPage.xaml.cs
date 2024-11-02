namespace AppMAUI.DemoSample;

public partial class 
										MainPage 
										: 
										ContentPage
{

	public 
										MainPage
										(											
										)
	{
		InitializeComponent();

		return;
	}

	private async
		void 
										OnPersonClicked
										(
											object sender, 
											EventArgs e
										)
	{
		/*

		*/
		// await Shell.Current.GoToAsync("//person");	// global route cannot be the only one
		await Shell.Current.GoToAsync("person");		// non global

		SemanticScreenReader.Announce(button_person.Text);

		return;
	}

	private async
		void 
										OnDateTimeClicked
										(
											object sender, 
											EventArgs e
										)
	{
		/*

		*/
		// await Shell.Current.GoToAsync("//person");	// global route cannot be the only one
		await Shell.Current.GoToAsync("datetime");		// non global

		SemanticScreenReader.Announce(button_datetime.Text);

		return;
	}
}

