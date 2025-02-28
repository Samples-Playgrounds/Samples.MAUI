using CSnakes.Runtime;

namespace AppMAUI.CSnakes;

public partial class MainPage : ContentPage
{
	int count = 0;
    private IHelloWorld helloWorld;

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

        PythonOutput1.Text = helloWorld.FormatName(PythonInput.Text);
        PythonOutput2.Text = helloWorld.HelloWorld(PythonInput.Text);

        return;
	}
}

