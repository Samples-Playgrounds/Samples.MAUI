namespace TakePhoto;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
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

	private async void OnTakePhotoButtonClicked(object sender, EventArgs e)
	{
		var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions {
			Title = "MyPhoto.jpg"
		});

		if (photo != null) {
			// Copy photo to cache directory
			var localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

			using var sourceStream = await photo.OpenReadAsync();
			using var localFileStream = File.OpenWrite(localFilePath);

			await sourceStream.CopyToAsync(localFileStream);

			// Display captured photo path in console
			Console.WriteLine($@"Photo saved to : {localFilePath}");
		}
	}
}


