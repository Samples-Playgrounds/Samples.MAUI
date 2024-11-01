namespace CleanApp.Views;

public partial class CountBubble : ContentView
{
    public static readonly BindableProperty CountProperty = 
        BindableProperty.Create("Count", typeof(int), typeof(CountBubble), 0);

    public int Count
    {
        get => (int)GetValue(CountProperty); 
        set => SetValue(CountProperty, value);
    }
	public CountBubble()
	{
		InitializeComponent();
	}
}