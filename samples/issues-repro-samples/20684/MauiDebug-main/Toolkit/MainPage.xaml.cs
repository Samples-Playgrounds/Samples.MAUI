using System.Text;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
namespace Toolkit;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		await SaveFile(CancellationToken.None);
	}

	async Task SaveFile(CancellationToken cancellationToken)
	{
		using var stream = new MemoryStream(Encoding.Default.GetBytes("Hello from the Community Toolkit!"));
		var fileSaverResult = await FileSaver.Default.SaveAsync("test.txt", stream, cancellationToken);
		if(fileSaverResult.IsSuccessful)
		{
			await Toast.Make($"The file was saved successfully to location: {fileSaverResult.FilePath}").Show(cancellationToken);
		}
		else
		{
			await Shell.Current?.DisplayAlert("error", fileSaverResult.Exception.Message, "OK");
		}
	}
}

