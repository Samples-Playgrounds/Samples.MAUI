using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls.Compatibility;

namespace Foundation
{
    public delegate void OnMenuItemTapped(MenuItem item);

    public delegate void OnNavigationTapped();

    public partial class NavigationBar : RelativeLayout
    {
        readonly int ItemSize;

        #region Bindable properties
        public static readonly BindableProperty IsRootProperty = BindableProperty.Create(
          nameof(IsRoot),
          typeof(bool),
          typeof(NavigationBar),
          true,
          propertyChanged: OnIsRootPropertyChanged
        );

        public static readonly BindableProperty IsModalProperty = BindableProperty.Create(
          nameof(IsModal),
          typeof(bool),
          typeof(NavigationBar),
          false
        );

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
          nameof(Title),
          typeof(string),
          typeof(NavigationBar),
          default(string),
          propertyChanged: OnTitlePropertyChanged
        );

        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(
          nameof(Items),
          typeof(IList<MenuItem>),
          typeof(NavigationBar),
          default(IList<MenuItem>),
          propertyChanged: OnItemsPropertyChanged);

        public static readonly new BindableProperty BackgroundColorProperty = BindableProperty.Create(
          nameof(BackgroundColor),
          typeof(Color),
          typeof(NavigationBar),
          default(Color),
          propertyChanged: OnBackgroundColorPropertyChanged);

        public static readonly new BindableProperty BackgroundImageSourceProperty = BindableProperty.Create(
          nameof(BackgroundImageSource),
          typeof(ImageSource),
          typeof(NavigationBar),
          default(ImageSource),
          propertyChanged: OnBackgroundImagePropertyChanged);

        public static readonly BindableProperty BackgroundOpacityProperty = BindableProperty.Create(
          nameof(BackgroundOpacity),
          typeof(double),
          typeof(NavigationBar),
          default(double),
          propertyChanged: OnBackgroundOpacityPropertyChanged);

        public static BindableProperty TitleTextColorProperty = BindableProperty.Create(
          nameof(TitleTextColor),
          typeof(Color),
          typeof(NavigationBar),
          default(Color),
          propertyChanged: OnTitleTextColorPropertyChanged);

        public static BindableProperty IconProperty = BindableProperty.Create(
          nameof(Icon),
          typeof(string),
          typeof(NavigationBar),
          default(string),
          propertyChanged: OnIconPropertyChanged);

        public static BindableProperty IsIconVisibleProperty = BindableProperty.Create(
          nameof(IsIconVisible),
          typeof(bool),
          typeof(NavigationBar),
          true,
          propertyChanged: OnIsIconVisiblePropertyChnaged);

        public bool IsRoot
        {
            get => (bool)GetValue(IsRootProperty);
            set => SetValue(IsRootProperty, value);
        }

        public bool IsModal
        {
            get => (bool)GetValue(IsModalProperty);
            set => SetValue(IsModalProperty, value);
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public IList<MenuItem> Items
        {
            get => (IList<MenuItem>)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        public double BackgroundOpacity
        {
            get => (double)GetValue(BackgroundOpacityProperty);
            set => SetValue(BackgroundOpacityProperty, value);
        }

        public new Color BackgroundColor
        {
            get => (Color)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        public ImageSource BackgroundImageSource
        {
            get => (ImageSource)GetValue(BackgroundImageSourceProperty);
            set => SetValue(BackgroundImageSourceProperty, value);
        }

        public Color TitleTextColor
        {
            get => (Color)GetValue(TitleTextColorProperty);
            set => SetValue(TitleTextColorProperty, value);
        }

        public bool IsIconVisible
        {
            get => (bool)GetValue(IsIconVisibleProperty);
            set => SetValue(IsIconVisibleProperty, value);
        }
        #endregion

        Image _navIcon;
        Label _navTitle;
        Image _backgroundView;

        public OnMenuItemTapped ItemClicked { get; set; }

        public OnNavigationTapped NavigationTapped { get; set; }

        public NavigationBar() : this(false)
        {
        }

        public NavigationBar(bool modal = false)
        {
            InitializeComponent();
            ItemSize = DeviceInfo.Platform == DevicePlatform.Android ? 48 : 44;

            IsModal = modal;
            SetupView();
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, width, height);
        }

        void SetupView()
        {
            _backgroundView = new TabbarHandlerIssue.CoreUI.Image
            {
                EdgeInsets = new TabbarHandlerIssue.CoreUI.EdgeInsets(6, 6, 0, 0),
                ResizeMode = TabbarHandlerIssue.CoreUI.ResizeMode.Stretch,
            };

            _navIcon = new Image
            {
                Source = NavIcon,
                WidthRequest = 60,
                HeightRequest = 60,
                Margin = new Thickness(0, 0, 0, 0)
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                NavigationTapped?.Invoke();
            };

            var navIconStack = new Microsoft.Maui.Controls.Grid
            {
                Padding = new Thickness(40, 8, 8, 8),
                Margin = new Thickness(0, 0, 0, 0),
                IsVisible = IsIconVisible,
                Children = { _navIcon }
            };

            navIconStack.GestureRecognizers.Add(tapGestureRecognizer);

            _navTitle = new Label
            {
                TextColor = Colors.White,
                MaxLines = 2,
                FontAttributes = FontAttributes.Bold,
                LineBreakMode = LineBreakMode.TailTruncation,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 20
            };

            Children.Add(_backgroundView,
                         Constraint.Constant(0),
                         Constraint.Constant(0),
                         Constraint.RelativeToParent(parent => parent.Width),
                         Constraint.RelativeToParent(parent => parent.Height));

            Children.Add(_navTitle,
                         Constraint.RelativeToParent(parent =>
                         {
                             var rightOffset = Math.Max(ItemSize + 8, (Items?.Count ?? 0) * ItemSize);
                             return rightOffset;
                         }),
                         Constraint.RelativeToParent(parent => parent.Height - ItemSize),
                         Constraint.RelativeToParent(parent =>
                         {
                             var rightOffset = Math.Max(ItemSize + 8, (Items?.Count ?? 0) * ItemSize);
                             return parent.Width - (rightOffset * 2);
                         }),
                         Constraint.Constant(ItemSize));

            Children.Add(navIconStack,
                         Constraint.Constant(0),
                         Constraint.RelativeToParent(parent => parent.Height - ItemSize),
                         Constraint.Constant(ItemSize),
                         Constraint.Constant(ItemSize));
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(IsRoot)
                || propertyName == nameof(IsModal))
            {
                UpdateNavIcon();
            }
        }

        ImageSource NavIcon =>
          string.IsNullOrEmpty(Icon)
          ? (IsRoot && !IsModal
             ? null
             : "ic_back_white_normal")
          : Icon;

        void UpdateNavIcon()
        {
            _navIcon.Source = NavIcon;
        }

        static void OnIsRootPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var self = bindable as NavigationBar;
            self._navIcon.Source = self.NavIcon;
        }

        static void OnTitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var self = bindable as NavigationBar;
            self._navTitle.Text = (string)newValue;
        }

        static void OnItemsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var self = bindable as NavigationBar;

            int childCount = self.Children.Count;
            for (var i = 3; i < childCount; i++)
            {
                self.Children.RemoveAt(3);
            }

            if (newValue != null && newValue is IList<MenuItem> items)
            {
                int index = items.Count;
                foreach (var item in items)
                {
                    item.View = (item.View != null) ? new Microsoft.Maui.Controls.StackLayout
                    {
                        Margin = new Thickness(8, 12, 8, 8),
                        Children =
                        {
                            item.View
                        }
                    } :
                    new Microsoft.Maui.Controls.StackLayout
                    {
                        Padding = new Thickness(8),
                        Children = { new Image
                        {
                            Source = item.Icon,
                            WidthRequest = 28,
                            HeightRequest = 28
                        }}
                    };

                    if (item.View != null)
                    {
                        item.View.GestureRecognizers.Add(new TapGestureRecognizer
                        {
                            Command = new Command(() => self.ItemClicked?.Invoke(item))
                        });
                    }

                    var i = index;
                    self.Children.Add(item.View,
                                      Constraint.RelativeToParent(parent =>
                                      {
                                          return parent.Width - (self.ItemSize * i);
                                      }),
                                      Constraint.RelativeToParent(parent => parent.Height - self.ItemSize),
                                      Constraint.Constant(self.ItemSize),
                                      Constraint.Constant(self.ItemSize));
                    index--;
                }
            }
        }

        static void OnBackgroundImagePropertyChanged(BindableObject bindable,
                                                    object oldValue,
                                                    object newValue)
        {
            var self = bindable as NavigationBar;
            self._backgroundView.Source = (FileImageSource)newValue;
        }

        static void OnBackgroundColorPropertyChanged(BindableObject bindable,
                                                      object oldValue,
                                                      object newValue)
        {
            var self = bindable as NavigationBar;
            self._backgroundView.BackgroundColor = (Color)newValue;
        }

        static void OnBackgroundOpacityPropertyChanged(BindableObject bindable,
                                                        object oldValue,
                                                        object newValue)
        {
            var self = bindable as NavigationBar;
            self._backgroundView.Opacity = (double)newValue;
        }

        static void OnTitleTextColorPropertyChanged(BindableObject bindable,
                                                    object oldValue,
                                                    object newValue)
        {
            var self = bindable as NavigationBar;
            self._navTitle.TextColor = (Color)newValue;
        }

        static void OnIconPropertyChanged(BindableObject bindable,
                                          object oldValue,
                                          object newValue)
        {
            var self = bindable as NavigationBar;
            self._navIcon.Source = (string)newValue;
        }

        static void OnIsIconVisiblePropertyChnaged(BindableObject bindable,
                                                  object oldValue,
                                                  object newValue)
        {
            var self = bindable as NavigationBar;
            self._navIcon.IsVisible = (bool)newValue;
        }
    }

    public class MenuItem
    {
        public string Key { get; set; }
        public string Icon { get; set; }
        public View View { get; set; }
    }
}