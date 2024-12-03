namespace FileNotFoundImage;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {

        var stream = await FileSystem.OpenAppPackageFileAsync("dotnet_bot.png");
        
        using var memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream);

        var byteImg = memoryStream.ToArray();
        // count++;
        //
        // if (count == 1)
        //     CounterBtn.Text = $"Clicked {count} time";
        // else
        //     CounterBtn.Text = $"Clicked {count} times";
        //
        // SemanticScreenReader.Announce(CounterBtn.Text);
    }
}