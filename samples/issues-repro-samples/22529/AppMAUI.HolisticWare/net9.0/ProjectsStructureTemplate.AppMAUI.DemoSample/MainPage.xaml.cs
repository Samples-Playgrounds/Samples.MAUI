namespace ProjectsStructureTemplate.AppMAUI.DemoSample;

public partial class MainPage : ContentPage
{
	// MainPage.xaml.cs(5,12): warning CA1805: 
	// Member 'count' is explicitly initialized to its default value
	// https://learn.microsoft.com/dotnet/fundamentals/code-analysis/quality-rules/ca1805
	// int count = 0;
	// int count = default;
	int count;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

