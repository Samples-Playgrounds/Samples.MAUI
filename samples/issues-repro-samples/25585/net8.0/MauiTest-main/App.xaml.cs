using CleanApp.Pages;

namespace CleanApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainFlyoutPage();
        }
    }
}
