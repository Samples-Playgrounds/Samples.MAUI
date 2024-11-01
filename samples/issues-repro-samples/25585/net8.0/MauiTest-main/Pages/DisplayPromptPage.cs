using System.Transactions;

namespace CleanApp.Pages;

public class DisplayPromptPage : ContentPage
{
    private readonly ActivityIndicator _busyActivity;
    private readonly Image _logoImage;
    private readonly Label _busyLabel;
    private readonly VerticalStackLayout _busyLayout;
    private readonly Label _errorLabel;
    private readonly Button _retryButton;
    private readonly Button _responseButton;
    private readonly VerticalStackLayout _errorLayout;
    private Grid _layout = new Grid();

    public DisplayPromptPage()
	{
        Disappearing += OnPageDisappearing;


        _logoImage = new Image()
        {
            Source = "dotnet_bot.png",
            Aspect = Aspect.AspectFit,
        };

        // Create the Activity Indicator
        _busyActivity = new ActivityIndicator
        {
            Color = Colors.Violet,
            Scale = 1.5,
        };
        // Create the Splash Label
        _busyLabel = new Label
        {
            TextColor = Colors.MediumPurple,
            Text = "Loading, please wait ...",
            FontSize = 20,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
        };
        _busyLayout = new VerticalStackLayout()
        {
            Padding = 10,
            Spacing = 6,
            IsVisible = false,
            Children = { _busyActivity, _busyLabel }
        };

        // Create the Splash Error Label
        _errorLabel = new Label
        {
            TextColor = Colors.MediumPurple,
            FontSize = 16,
            HorizontalTextAlignment = TextAlignment.Center,
            LineBreakMode = LineBreakMode.WordWrap,
            MaximumWidthRequest = DeviceDisplay.Current.MainDisplayInfo.Width - 150
        };

        // Create the Connect Button
        // (To bind the version check to the UI)
        _retryButton = new Button
        {
            Text = "Try Again",
            TextColor = Colors.MediumPurple,
            IsVisible = false
        };
        _retryButton.Clicked += (sender, args) => Prompt();

        // Create the JGo response Button
        // (To allow a new Connection code to be prompted/used)
        _responseButton = new Button
        {
            Text = "New Connection Code",
            TextColor = Colors.MediumPurple,
            IsVisible = false
        };
        _responseButton.Clicked += OnResponseButtonClicked;

        // Create the Layout for the Splash Error Label
        _errorLayout = new VerticalStackLayout()
        {
            Padding = 20,
            Spacing = 20,
            IsVisible = false,
            Children = { _errorLabel, _retryButton, _responseButton }
        };

        SizeChanged += (sender, e) => SetOrientation(sender, e, this);
        Prompt();
    }

    private void OnPageDisappearing(object sender, EventArgs e)
    {
        ////Unsubscribe to _errorDisplay events
        _responseButton.Clicked -= OnResponseButtonClicked;
    }

    private async void Prompt()
    {
        _errorLayout.IsVisible = false;
        _busyActivity.IsRunning = _busyLabel.IsVisible = _busyLayout.IsVisible = true;

        // **** Uncomment the await below to get the prompt to display **** //
        //await Task.Delay(50);
        // Prompt 
        var response = await DisplayPromptAsync("Title", "Enter Response");
        //await DisplayAlert("Title", "Enter Response", "close");
        //var response = await DisplayActionSheet("Title", null, null, "One", "Two", "Three");
        _busyActivity.IsRunning = _busyLabel.IsVisible = _busyLayout.IsVisible = false;
    }

    private void SetOrientation(object sender, EventArgs e, ContentPage p)
    {
        _layout.RowDefinitions.Clear();
        _layout.ColumnDefinitions.Clear();
        _layout.Remove(_logoImage);
        _layout.Remove(_errorLayout);
        _layout.Remove(_busyLayout);
        if (p.Width > p.Height)
            CreateLandscapeLayout();
        else
            CreatePortraitLayout();
        _layout.BackgroundColor = Colors.LightGrey;
        Content = _layout;
    }

    private void CreatePortraitLayout()
    {
        var imageHeight = DeviceDisplay.Current.MainDisplayInfo.Height /
                          DeviceDisplay.Current.MainDisplayInfo.Density / 4;
        _layout.RowDefinitions =
        [
            new RowDefinition { Height = GridLength.Star },
                new RowDefinition { Height = imageHeight },
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = GridLength.Star }
        ];
        _layout.ColumnDefinitions =
        [
            new ColumnDefinition { Width = GridLength.Star },
                new ColumnDefinition { Width = GridLength.Auto },
                new ColumnDefinition { Width = GridLength.Star },
            ];

        _layout.Add(_logoImage, 1, 1);
        _layout.AddWithSpan(_errorLayout, 2, 0, 1, 3);
        _errorLayout.Padding = 20;
        _layout.Add(_busyLayout, 1, 2);
    }
    private void CreateLandscapeLayout()
    {
        _layout.RowDefinitions =
        [
            new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
            ];

        _layout.ColumnDefinitions =
        [
            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
            ];

        _layout.AddWithSpan(_logoImage, 1, 1, 3);
        _layout.Add(_errorLayout, 2, 2);
        _errorLayout.Padding = 0;
        _layout.Add(_busyLayout, 2, 2);
    }

    private void OnResponseButtonClicked(object sender, EventArgs e)
    {
        Prompt();
    }



}