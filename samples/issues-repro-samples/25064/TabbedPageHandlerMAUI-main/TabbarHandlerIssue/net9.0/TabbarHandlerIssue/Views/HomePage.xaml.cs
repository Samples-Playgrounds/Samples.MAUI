using TabbarHandlerIssue.Foundation;

namespace TabbarHandlerIssue.Views;

public partial class HomePage : Foundation.TabbedPage, IAlertHandler
{
    public HomePage()
    {
        InitializeComponent();

        ItemsSource = new List<TabItem>
            {
                new TabItem
                {
                    Title ="Message",
                    ImageSource = new ImageSourceStateList("message_inactive","message_active")
                },
                new TabItem
                {
                    Title ="Leave",
                    ImageSource = new ImageSourceStateList("leave_inactive","leave_active")
                },
                new TabItem
                {
                    Title ="Appointment",
                    ImageSource = new ImageSourceStateList("appointment_inactive","appointment_active")
                }
                ,new TabItem
                {
                    Title ="Home",
                    ImageSource = new ImageSourceStateList("home_inactive","home_active")
                }
            };

        CurrentPage = Children[3];

        ItemTemplate = new TabbedDataTemplateSelector();
        MessagingCenter.Unsubscribe<object, int>(this, "tab_selected");
        MessagingCenter.Subscribe<object, int>(this, "tab_selected",
            (arg, idx) => { CurrentPage = Children[idx]; });
    }

    protected override void OnCurrentPageChanged()
    {
        base.OnCurrentPageChanged();

    }
}
