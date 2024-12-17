using Microsoft.Maui.Controls.PlatformConfiguration;
using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;
 using CommunityToolkit.Mvvm.Messaging;


namespace TestStatusBar
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            SetStatusBarColor(false, Color.FromArgb("#FFA500"));
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("SecondPage");
        }

        public void SetStatusBarColor(bool isLightMode, Color color)
        {
            var behaviours = Behaviors.Where(b => b is StatusBarBehavior);
            if (behaviours != null)
            {
                foreach (var behaviour in behaviours)
                {
                    Dispatcher.Dispatch(() => Behaviors.Remove(behaviour));
                }
            }

            StatusBarStyle statusBarStyle = StatusBarStyle.LightContent;

            Dispatcher.Dispatch(() =>
            {
                Behaviors.Add(new StatusBarBehavior
                {
                    StatusBarColor = color,
                    StatusBarStyle = statusBarStyle
                });
            });
        }
    }

}
