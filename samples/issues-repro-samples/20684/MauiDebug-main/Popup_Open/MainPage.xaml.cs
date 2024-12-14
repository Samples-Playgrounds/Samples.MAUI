using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Toolkit;
namespace ANR;

public partial class MainPage : ContentPage
{
	public Model Model { get; } = new();

	public MainPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
	}

	private async void ToolbarItem_Clicked(object sender, EventArgs e)
	{
		await Model.Add();
	}

	private void ScrollToSelection(object sender, SelectionChangedEventArgs e)
	{
		if(sender is ItemsView view && e.CurrentSelection?.Count > 0)
		{
			view.ScrollTo(e.CurrentSelection[0], animate: false);
		}
	}
}

public partial class Model : INotifyPropertyChanged
{
	public Item SelectedItem { get; set; }

	public ObservableCollection<Item> ItemList { get; } = new();

	public async Task Add()
	{
		await ProgressPage.Show(() => MainThread.BeginInvokeOnMainThread(delegate
		{
			var item = new Item();
			ItemList.Add(item);
			SelectedItem = item;
			OnPropertyChanged(nameof(SelectedItem));
		}));
	}

	public event PropertyChangedEventHandler PropertyChanged;
	public void OnPropertyChanged([CallerMemberName] string propertyName = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}

public partial class Item
{
	public string Name { get; set; } = "Item";
	public bool IsEnable { get; set; }
	public string Title { get; set; } = "Title";

	public ObservableCollection<SubItem> SubitemList { get; } = new() { new(), new(), new(), new(), new() };
}

public class SubItem
{
	public string Name { get; set; } = "SubItem";
	public string Description { get; set; } = "Description";
}

