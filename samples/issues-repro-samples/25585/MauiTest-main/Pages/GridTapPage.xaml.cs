using Microsoft.Maui.ApplicationModel.Communication;

namespace CleanApp.Pages;

public partial class GridTapPage : ContentPage
{
    private string email = "TestEmail@gmail.com";
    private string phone = "867-5309";

    public GridTapPage()
	{
		InitializeComponent();

        ContacteMail.Text = "Email " + email;
        MailImage.Source = "email.png";

        ContactPhone.Text = "Call " + phone;
        PhoneImage.Source = "phone.png";
    }

    private void MailLayout_OnTapped(object sender, TappedEventArgs e)
    {
        Launcher.OpenAsync(new Uri("mailto:" + email));
    }

    private void PhoneLayout_OnTapped(object sender, TappedEventArgs e)
    {
        Launcher.OpenAsync(new Uri("tel:" + phone));
    }
}