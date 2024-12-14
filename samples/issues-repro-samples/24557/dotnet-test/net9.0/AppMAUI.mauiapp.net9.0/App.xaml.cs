namespace AppMAUI.mauiapp.net9._0
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            UserAppTheme = PlatformAppTheme;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new MainPage());
            window.Title = "AppMAUI.mauiapp.net9._0";
            return window;
        }
    }
}
