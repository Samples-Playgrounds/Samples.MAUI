using Plugin.LocalNotification;

namespace Sample.Issue_12291.PostNotifications;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
        NotificationRequest request = new NotificationRequest
        {
            NotificationId = 1000,
                Title = "NotificationRequest",
                Subtitle = "Subscribe",
                Description = "Issue_12291.PostNotifications",
                BadgeNumber = 42,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(5),
                    NotifyRepeatInterval = TimeSpan.FromDays(1)
                }
        };

        LocalNotificationCenter.Current.Show(request);

        return;
	}
}

