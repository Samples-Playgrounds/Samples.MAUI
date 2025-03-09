using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls.Compatibility;

namespace Foundation
{
    [ContentProperty("View")]
    public partial class BaseContentPage : BasePage
    {
        public static readonly BindableProperty ViewProperty = BindableProperty.Create(
          nameof(View),
          typeof(View),
          typeof(BaseContentPage),
          default(View),
          propertyChanged: OnViewPropertyChanged);

        public static readonly BindableProperty IsNavBarShadowVisibleProperty = BindableProperty.Create(
          nameof(IsNavBarShadowVisible),
          typeof(bool),
          typeof(BaseContentPage),
          true,
          propertyChanged: OnNavBarVisiblePropertyChanged);

        public View View
        {
            get => (View)GetValue(ViewProperty);
            set => SetValue(ViewProperty, value);
        }

        public bool IsNavBarShadowVisible
        {
            get => (bool)GetValue(IsNavBarShadowVisibleProperty);
            set => SetValue(IsNavBarShadowVisibleProperty, value);
        }

        ContentView _contentView;
        View _shadow;
        readonly protected NavigationBar NavigationBar;

        public BaseContentPage()
        {
            InitializeComponent();

            var navBarHeight = 44 + AppDeviceInfo.Insets.Top;
            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                navBarHeight += 4;
            }

            NavigationBar = new NavigationBar
            {
                Title = Title,
                IsRoot = IsRoot,
                IsModal = IsModal,
                //BackgroundColor = (Color)Application.Current.Resources["AppColor"],
                //TitleTextColor = (Color)Application.Current.Resources["DarkTextColor"],
            };

            _contentView = new ContentView();

            RootView.Children.Add(NavigationBar,
                                  Constraint.Constant(0),
            Constraint.Constant(0),
                                  Constraint.RelativeToParent(parent => parent.Width),
                                  Constraint.Constant(navBarHeight));

            RootView.Children.Add(_contentView,
                                  Constraint.Constant(0),
                                  Constraint.Constant(navBarHeight),
                                  Constraint.RelativeToParent(parent => parent.Width),
                                  Constraint.RelativeToParent(parent => parent.Height - navBarHeight));
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(Title))
            {
                NavigationBar.Title = Title;
            }
            else if (propertyName == nameof(IsRoot))
            {
                NavigationBar.IsRoot = IsRoot;
            }
            else if (propertyName == nameof(IsModal))
            {
                NavigationBar.IsModal = IsModal;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationBar.NavigationTapped += OnNavigationTapped;
        }

        protected override void OnDisappearing()
        {
            NavigationBar.NavigationTapped -= OnNavigationTapped;
            base.OnDisappearing();
        }

        void OnNavigationTapped()
        {
            if (IsModal)
            {
                NavigationDelegate.PopModalAsync();
            }
            else if (NavigationDelegate.NavigationStack.Count > 1)
            {
                NavigationDelegate.PopAsync();
            }
        }

        static void OnViewPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var self = bindable as BaseContentPage;
            self._contentView.Content = (View)newValue;
        }

        static void OnNavBarVisiblePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var self = bindable as BaseContentPage;
            self._shadow.IsVisible = (bool)newValue;
        }
    }

    public static class AppDeviceInfo
    {
        public static Thickness Insets { get; private set; }

        /// <summary>
        /// A hack that is set on splash to be able to retrieve windows properties such as width, height
        /// and etc. Should be set only during startup.
        /// </summary>
        public static void Init(Thickness insets)
        {
            Insets = insets;
        }
    }
}