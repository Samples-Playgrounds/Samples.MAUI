namespace CheckBoxCrash;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnAddSwitch(object sender, EventArgs e)
	{
		Panel.Children.Clear();
		for(int i = 0; i < 1000; i++)
		{
			Panel.Children.Add(new Switch());
		}
	}

	private void OnAddCheckBox(object sender, EventArgs e)
	{
		Panel.Children.Clear();
		for(int i = 0; i < 1000; i++)
		{
			Panel.Children.Add(new CheckBox());
		}
	}
}

