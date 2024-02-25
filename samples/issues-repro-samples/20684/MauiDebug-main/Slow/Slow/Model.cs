using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Data;

public class Model : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;

	/// <summary>
	/// 更新属性
	/// </summary>
	/// <param name="propertyName">属性名</param>
	public void OnPropertyChanged([CallerMemberName] string propertyName = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	public int Time { get; set; }
	public ObservableCollection<Item> ItemList { get; set; } = new();

	public Command RefreshCommand { get; }

	public void Refresh()
	{
		var tick = Environment.TickCount;
		var list = new List<Item>();
		for(int i = 0; i < 100000; i++)
		{
			list.Add(new Item());
		}

		ItemList = new ObservableCollection<Item>(list);
		OnPropertyChanged(nameof(ItemList));

		Time = Environment.TickCount - tick;
		OnPropertyChanged(nameof(Time));
	}

	public Model()
	{
		RefreshCommand = new Command(Refresh);
	}
}

public class Item
{
	static int Count = 0;
	public string Name { get; set; } = $"{Count++}";
	public bool IsEnable { get; set; }
	public string Title { get; set; } = "Title";

	public ObservableCollection<SubItem> SubitemList { get; } = new ObservableCollection<SubItem> { new(), new(), new(), new(), new() };
}

public class SubItem
{
	public string Name { get; set; } = "SubItem";
	public string Description { get; set; } = "Description";
}

