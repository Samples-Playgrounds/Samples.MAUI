namespace CleanApp.Pages
{
    public partial class TitleIssuePage : BasePage
    {

        public TitleIssuePage()
        {
            InitializeComponent();

        }

        private void OnResetBothButtonClicked(object sender, EventArgs e)
        {
            if (Utilities.GetPage<MainFlyoutPage>(this) is MainFlyoutPage flyoutPage)
            {
                flyoutPage.Detail = new NavigationPage(new AnnouncementPage());
                flyoutPage.Flyout = new MenuPage();
            }
        }

        private void OnResetDetailButtonClicked(object sender, EventArgs e)
        {
            if (Utilities.GetPage<MainFlyoutPage>(this) is MainFlyoutPage flyoutPage)
            {
                flyoutPage.Detail = new NavigationPage(new AnnouncementPage());
            }
        }
        private void OnResetFlyoutButtonClicked(object sender, EventArgs e)
        {
            if (Utilities.GetPage<MainFlyoutPage>(this) is MainFlyoutPage flyoutPage)
            {
                flyoutPage.Flyout = new MenuPage();
            }
        }
    }

}
