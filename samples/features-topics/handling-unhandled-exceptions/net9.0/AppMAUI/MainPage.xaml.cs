namespace AppMAUI;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

        int divisor = DateTime.Now.Second % 10;
        Console.WriteLine($"{divisor}");
        
		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

        double result_division = count / divisor;
        
		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

