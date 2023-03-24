using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace Sample.Issue_10385.MediaPickerCrash.ViewModels;

public class Main
{
    public Main()
    {
        ShowMoreInfoCommand = new AsyncRelayCommand(ShowMoreInfo);

        return;
    }

    public string MoreInfoUrl
        =>
        // "https://aka.ms/maui"
        "https://github.com/dotnet/maui/issues/10385"
        ;

    public ICommand ShowMoreInfoCommand
    {
        get;
    }

    async Task ShowMoreInfo() =>
        await Launcher.Default.OpenAsync(MoreInfoUrl);
}

