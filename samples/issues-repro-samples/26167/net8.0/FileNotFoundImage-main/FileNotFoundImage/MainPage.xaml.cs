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
        var s1 = await FileSystem.OpenAppPackageFileAsync("dotnet_bot.png");
        
        using var ms1 = new MemoryStream();
        await s1.CopyToAsync(ms1);
        
        var byteImg1 = ms1.ToArray();
        
        var s2 = await FileSystem.OpenAppPackageFileAsync("dotnet_bot_raw.png");
        
        using var ms2 = new MemoryStream();
        await s2.CopyToAsync(ms1);
        
        var byteImg2 = ms1.ToArray();
    }
}