namespace Sample.Issue_13446.SMS_Perimisions;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnSMSSendButtonClicked(object sender, EventArgs e)
	{
		string phone = entry_phone.Text;
		string message = editor_message.Text;

        #if __ANDROID__
        Platforms.Android.SMS sms = new Platforms.Android.SMS();
		sms.Send(phone, message);
		#endif

		return;
	}
}

