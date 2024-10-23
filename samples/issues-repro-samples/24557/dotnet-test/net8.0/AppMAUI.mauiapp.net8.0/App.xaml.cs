namespace AppMAUI.mauiapp.net8._0
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            UserAppTheme = PlatformAppTheme;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Title = "AppMAUI.mauiapp.net8._0";
            return window;
        }
    }
}
