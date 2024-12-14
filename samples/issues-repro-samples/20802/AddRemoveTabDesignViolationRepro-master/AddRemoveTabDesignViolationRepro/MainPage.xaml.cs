using System.Timers;
using Timer = System.Timers.Timer;

namespace AddRemoveTabDesignViolationRepro;

public partial class MainPage : TabbedPage
{
    private NavigationPage _removedPage;
    
    public MainPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var timer = new Timer(10000);
        timer.AutoReset = true;
        timer.Elapsed += TimerOnElapsed;
        timer.Start();
    }

    private void TimerOnElapsed(object? sender, ElapsedEventArgs e)
    {
        MainThread.InvokeOnMainThreadAsync(() =>
        {
            if (Children.Count == 4)
            {
                _removedPage = (NavigationPage)Children[2];
                Children.RemoveAt(2);
            }
            else
            {
                Children.Insert(2, _removedPage);
            }
        });
    }
}