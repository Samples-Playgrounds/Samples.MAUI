using Android.Content;
using Android.Views;
using Android.Widget;
using Google.Android.Material.Tabs;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Graphics = Android.Graphics;

namespace TabbarHandlerIssue.Platforms.Android
{
    public class TabbedPageHandler : ViewHandler<Foundation.TabbedPage, ViewGroup>
    {
        private TabLayout _tabLayout;
        private FrameLayout _containerView;
        private FrameLayout _contentView;
        private int _position = -1;

        public TabbedPageHandler() : base(ViewMapper)
        {
        }

        protected override ViewGroup CreatePlatformView()
        {
            _containerView = new FrameLayout(Context)
            {
                LayoutParameters = new ViewGroup.LayoutParams(
                    ViewGroup.LayoutParams.MatchParent,
                    ViewGroup.LayoutParams.MatchParent)
            };

            _tabLayout = new TabLayout(Context)
            {
                LayoutParameters = new ViewGroup.LayoutParams(
                    ViewGroup.LayoutParams.MatchParent,
                    100)
            };

            _contentView = new FrameLayout(Context)
            {
                LayoutParameters = new FrameLayout.LayoutParams(
                    ViewGroup.LayoutParams.MatchParent,
                    ViewGroup.LayoutParams.MatchParent)
            };

            _containerView.AddView(_contentView);
            _containerView.AddView(_tabLayout);

            ConfigureTabLayoutAppearance();

            return _containerView;
        }

        private void ConfigureTabLayoutAppearance()
        {
            _tabLayout.SetBackgroundColor(Graphics.Color.White);

            _tabLayout.SetSelectedTabIndicatorColor(Graphics.Color.Transparent);
            _tabLayout.SetSelectedTabIndicatorHeight(0);
        }

        protected override void ConnectHandler(ViewGroup platformView)
        {
            base.ConnectHandler(platformView);

            if (platformView == null)
            {
                Console.WriteLine("ConnectHandler: platformView is null.");
                return;
            }

            _containerView = platformView as FrameLayout;
            if (_containerView == null)
            {
                Console.WriteLine("ConnectHandler: _containerView is null after casting.");
                return;
            }

            if (VirtualView != null)
            {
                VirtualView.PropertyChanged += OnTabbedPagePropertyChanged;
                SetupTabLayoutItems();
                UpdateTabViewState();
                SetupContainer();
            }
        }

        protected override void DisconnectHandler(ViewGroup platformView)
        {
            if (VirtualView != null)
            {
                VirtualView.PropertyChanged -= OnTabbedPagePropertyChanged;
            }

            if (_tabLayout != null)
            {
                _tabLayout.TabSelected -= OnTabLayoutTabSelected;
            }

            base.DisconnectHandler(platformView);
        }

        private void SetupTabLayoutItems()
        {
            if (VirtualView == null || !(VirtualView.ItemsSource is List<Foundation.TabItem> items))
            {
                Console.WriteLine("SetupTabLayoutItems: VirtualView is null or ItemsSource is not a List<TabItem>.");
                return;
            }

            _tabLayout.RemoveAllTabs();

            foreach (var item in items.Select((item, index) =>
            {
                var tab = _tabLayout.NewTab();

                var tabView = new LinearLayout(Context)
                {
                    Orientation = Orientation.Vertical
                };

                var imageView = new ImageView(Context);
                var textView = new TextView(Context)
                {
                    Text = item.Title,
                    Gravity = GravityFlags.Center
                };

                var drawable = Context.GetDrawable(GetDrawableResourceId(item.ImageSource.Normal));
                imageView.SetImageDrawable(drawable);

                tabView.AddView(imageView);
                tabView.AddView(textView);

                var layoutParams = new LinearLayout.LayoutParams(
                    ViewGroup.LayoutParams.WrapContent,
                    ViewGroup.LayoutParams.WrapContent)
                {
                    TopMargin = 8,
                    BottomMargin = 5
                };
                tabView.LayoutParameters = layoutParams;

                tabView.Tag = index;

                tab.SetCustomView(tabView);

                return tab;
            }))
            {
                _tabLayout.AddTab(item);
            }

            _tabLayout.TabSelected += OnTabLayoutTabSelected;
        }

        private void OnTabLayoutTabSelected(object sender, TabLayout.TabSelectedEventArgs e)
        {
            var index = (int)((LinearLayout)e.Tab.CustomView).Tag;
            var page = VirtualView;
            if (page == null || index < 0 || index >= page.Children.Count)
            {
                Console.WriteLine("OnTabLayoutTabSelected: Index out of bounds or page is null.");
                return;
            }

            if (page.WillAllowNavigate(index))
            {
                page.CurrentPage = page.Children[index];
                UpdateTabViewState();
            }
        }

        private void OnTabbedPagePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(TabbedPage.CurrentPage))
            {
                UpdateTabViewState();
            }
        }

        private void UpdateTabViewState()
        {
            try
            {
                var page = VirtualView;
                if (page == null || _tabLayout == null)
                {
                    Console.WriteLine("UpdateTabViewState: VirtualView or _tabLayout is null.");
                    return;
                }

                var newPosition = page.Children.IndexOf(page.CurrentPage);
                if (newPosition == _position || !page.WillAllowNavigate(newPosition))
                {
                    Console.WriteLine("UpdateTabViewState: Position unchanged or navigation not allowed.");
                    return;
                }

                if (_position != -1)
                {
                    var previousTab = _tabLayout.GetTabAt(_position);
                    if (previousTab != null && previousTab.CustomView is LinearLayout previousTabView)
                    {
                        var imageView = previousTabView.GetChildAt(0) as ImageView;
                        if (imageView != null)
                        {
                            imageView.SetImageDrawable(Context.GetDrawable(GetDrawableResourceId(((List<Foundation.TabItem>)VirtualView.ItemsSource)?[_position].ImageSource.Normal)));
                        }
                    }
                }

                var currentTab = _tabLayout.GetTabAt(newPosition);
                if (currentTab != null && currentTab.CustomView is LinearLayout currentTabView)
                {
                    var imageView = currentTabView.GetChildAt(0) as ImageView;
                    if (imageView != null)
                    {
                        imageView.SetImageDrawable(Context.GetDrawable(GetDrawableResourceId(((List<Foundation.TabItem>)VirtualView.ItemsSource)?[newPosition].ImageSource.Focused)));
                    }
                }

                _position = newPosition;

                _tabLayout.GetTabAt(newPosition)?.Select();
                _tabLayout.RequestLayout();
                DisplayCurrentPage();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateTabViewState: {ex.Message}");
            }
        }

        private void DisplayCurrentPage()
        {
            if (VirtualView == null || _contentView == null)
                return;

            _contentView.RemoveAllViews();

            var currentPage = VirtualView.CurrentPage;
            if (currentPage != null)
            {
                var platformView = currentPage.ToPlatform(MauiContext);
                platformView.LayoutParameters = new FrameLayout.LayoutParams(
                    ViewGroup.LayoutParams.MatchParent,
                    ViewGroup.LayoutParams.MatchParent);

                _contentView.AddView(platformView);
            }
        }

        private void SetupContainer()
        {
            if (_tabLayout == null || _containerView == null || _contentView == null)
            {
                Console.WriteLine("SetupContainer: One or more views are null.");
                return;
            }

            var tabLayoutHeight = 100;

            _contentView.LayoutParameters = new FrameLayout.LayoutParams(
                ViewGroup.LayoutParams.MatchParent,
                ViewGroup.LayoutParams.MatchParent,
                GravityFlags.Top);

            _tabLayout.LayoutParameters = new FrameLayout.LayoutParams(
                ViewGroup.LayoutParams.MatchParent,
                tabLayoutHeight,
                GravityFlags.Bottom);

            _contentView.SetPadding(0, 0, 0, tabLayoutHeight);

            _containerView.RequestLayout();
        }

        private int GetDrawableResourceId(string resourceName)
        {
            var resourceId = Context.Resources.GetIdentifier(resourceName, "drawable", Context.PackageName);
            return resourceId;
        }
    }
}

