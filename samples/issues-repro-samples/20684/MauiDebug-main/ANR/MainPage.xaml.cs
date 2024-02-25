using System.Collections.ObjectModel;
namespace ANR;

public partial class MainPage : ContentPage
{
	private static int Tick = Environment.TickCount;
	private static int TickCount = 0;
	public ObservableCollection<Item> ItemList { get; set; } = [];

	public MainPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

	private void ToolbarItem_Clicked(object sender, EventArgs e)
	{
		Tick = Environment.TickCount;
		var list = new List<Item>();
		for(int i = 0; i < 100; i++)
		{
			list.Add(new Item());
		}
		ItemList = new(list);
		OnPropertyChanged(nameof(ItemList));
	}

	private void Insert_Clicked(object sender, EventArgs e)
	{
		Tick = Environment.TickCount;
		ItemList.Insert(0, new Item() { TickCount = TickCount, Operate = "Insert" });
		Collection.ScrollTo(0);
	}

	private void Add_Clicked(object sender, EventArgs e)
	{
		Tick = Environment.TickCount;
		ItemList.Add(new Item() { TickCount = TickCount, Operate = "Add" });
		Collection.ScrollTo(ItemList.Count);
	}

	private void Collection_ChildAdded(object sender, ElementEventArgs e)
	{
		TickCount = Environment.TickCount - Tick;
	}
}

public class Item
{
	static int Count = 0;
	public string Name { get; set; } = $"{Count++}";
	public bool IsEnable { get; set; }
	public string Operate { get; set; }
	public int TickCount { get; set; }

	public ObservableCollection<SubItem> SubitemList { get; } = new ObservableCollection<SubItem> { new(), new(), new(), new(), new() };
}

public class SubItem
{
	public string Name { get; set; } = "SubItem";
	public string Description { get; set; } = "Description";
}

