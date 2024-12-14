using System.Collections.ObjectModel;
namespace HorizontalList;

public partial class MainPage : ContentPage
{
	public ObservableCollection<Item> ItemList { get; set; }

	public MainPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		var list = new List<Item>();
		for(int i = 0; i < 10; i++)
		{
			list.Add(new Item());
		}
		ItemList = new(list);
		OnPropertyChanged(nameof(ItemList));
	}
}

public class Item
{
	static int Count = 0;
	public string Name { get; set; } = $"{Count++}";
}