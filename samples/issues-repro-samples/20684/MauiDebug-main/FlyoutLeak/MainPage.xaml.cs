namespace FlyoutLeak;

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
		if(count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		Shell.Current.FlyoutBehavior = count % 2 == 0 ? FlyoutBehavior.Flyout : FlyoutBehavior.Disabled;
		Dispatcher.DispatchDelayed(TimeSpan.FromSeconds(0.01), () => OnCounterClicked(sender, e));
	}
}

