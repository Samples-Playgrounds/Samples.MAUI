using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace CleanApp.Pages
{
    public class MainFlyoutPage : FlyoutPage
    {
        public MainFlyoutPage()
        {
            Flyout = new MenuPage();
            Detail = new NavigationPage(new AnnouncementPage());

        }
    }
}