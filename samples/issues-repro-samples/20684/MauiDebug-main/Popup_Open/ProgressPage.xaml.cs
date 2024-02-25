using CommunityToolkit.Maui.Views;
namespace Toolkit;

public partial class ProgressPage : Popup
{
	public ProgressPage()
	{
		InitializeComponent();
	}

	public async static Task Show(Action action = null)
	{
		var popup = new ProgressPage();
		var tick = Environment.TickCount;
		//popup.Opened += (s, e) => Task.Delay(800).ContinueWith(s =>
		//{
		//	action?.Invoke();
		//	Thread.Sleep(500);
		//	MainThread.BeginInvokeOnMainThread(() => popup.Close());
		//});
		popup.Opened += (s, e) => ThreadPool.QueueUserWorkItem(delegate
		{
			action?.Invoke();
			Thread.Sleep(500);
			MainThread.BeginInvokeOnMainThread(() => popup.Close());
		});

		await Shell.Current.CurrentPage.ShowPopupAsync(popup);
	}
}