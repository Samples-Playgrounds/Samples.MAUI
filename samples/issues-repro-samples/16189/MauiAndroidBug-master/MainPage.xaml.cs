using System.Collections.ObjectModel;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    int count = 0;
    ObservableCollection<string> items = new ObservableCollection<string>();
    public ObservableCollection<string> Items { get { return items; } }

    public MainPage()
    {
        InitializeComponent();
        Items.Add("Text to see");
        Items.Add("Text to see1");
        Items.Add("Text to see2");
        Items.Add("Text to see3");
        Items.Add("Text to see4");
        Items.Add("Text to see5");
        Items.Add("Text to see6");
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

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        App.Current.MainPage.DisplayAlert("Info", e.SelectedItem.ToString(), "ok");
    }
}

