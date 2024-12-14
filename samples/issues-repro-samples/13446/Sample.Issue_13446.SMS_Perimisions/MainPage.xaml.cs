using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Sample.Issue_13446.SMS_Perimisions.Platforms.Android;

namespace Sample.Issue_13446.SMS_Perimisions;

public partial class MainPage : ContentPage
{
    public MainPage()
	{
		InitializeComponent();

		this.BindingContext = this.SMS;

		return;
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

	public SMS SMS
	{
		get;
		set;
	}
}

