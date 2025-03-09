using CoreGraphics;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using UIKit;

namespace TabbarHandlerIssue.Platforms.iOS
{
    public class TabbedPageHandler : ViewHandler<Foundation.TabbedPage, UIView>
    {
        private UITabBar _tabBar;
        private UIView _containerView;
        private UIView _contentView;
        private int _position = -1;

        public TabbedPageHandler() : base(ViewMapper)
        {
        }

        protected override UIView CreatePlatformView()
        {
            _containerView = new UIView
            {
                Frame = UIScreen.MainScreen.Bounds,
                BackgroundColor = UIColor.White
            };

            _contentView = new UIView
            {
                BackgroundColor = UIColor.White
            };

            _tabBar = new UITabBar
            {
                BackgroundColor = UIColor.Clear,
                Frame = new CGRect(0, _containerView.Frame.Height - 90, _containerView.Frame.Width, 90)
            };

            _containerView.AddSubview(_contentView);
            _containerView.AddSubview(_tabBar);

            ConfigureTabBarAppearance();

            return _containerView;
        }

        private void ConfigureTabBarAppearance()
        {
            var appearance = new UITabBarAppearance
            {
                BackgroundColor = UIColor.Clear
            };

            appearance.ConfigureWithTransparentBackground();

            var normalAttributes = new UIStringAttributes
            {
                ForegroundColor = UIColor.Clear
            };

            var selectedAttributes = new UIStringAttributes
            {
                ForegroundColor = UIColor.Clear
            };

            appearance.StackedLayoutAppearance.Normal.TitleTextAttributes = normalAttributes;
            appearance.StackedLayoutAppearance.Selected.TitleTextAttributes = selectedAttributes;

            _tabBar.StandardAppearance = appearance;
            _tabBar.ScrollEdgeAppearance = appearance;

            _tabBar.ShadowImage = new UIImage();
            _tabBar.BackgroundImage = new UIImage();

            _tabBar.SetNeedsLayout();
            _tabBar.LayoutIfNeeded();
        }

        protected override void ConnectHandler(UIView platformView)
        {
            base.ConnectHandler(platformView);

            if (platformView == null)
            {
                Console.WriteLine("ConnectHandler: platformView is null.");
                return;
            }

            _containerView = platformView as UIView;
            if (_containerView == null)
            {
                Console.WriteLine("ConnectHandler: _containerView is null after casting.");
                return;
            }

            if (VirtualView != null)
            {
                VirtualView.PropertyChanged += OnTabbedPagePropertyChanged;
                SetupTabBarItems();
                UpdateTabViewState();
                SetupContainer();
            }
        }

        protected override void DisconnectHandler(UIView platformView)
        {
            if (VirtualView != null)
            {
                VirtualView.PropertyChanged -= OnTabbedPagePropertyChanged;
            }

            if (_tabBar != null)
            {
                _tabBar.ItemSelected -= OnTabBarItemSelected;
            }

            base.DisconnectHandler(platformView);
        }

        private void SetupTabBarItems()
        {
            if (VirtualView == null || !(VirtualView.ItemsSource is List<Foundation.TabItem> items))
            {
                Console.WriteLine("SetupTabBarItems: VirtualView is null or ItemsSource is not a List<TabItem>.");
                return;
            }

            var tabBarItems = items.Select((item, index) =>
            {
                var tabBarItem = new UITabBarItem
                {
                    Image = UIImage.FromBundle(item.ImageSource.Normal).ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal),
                    SelectedImage = UIImage.FromBundle(item.ImageSource.Focused).ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal),
                    Title = item.Title,
                    Tag = index
                };

                tabBarItem.ImageInsets = new UIEdgeInsets(5, 0, -5, 0);

                return tabBarItem;
            }).ToArray();

            _tabBar.Items = tabBarItems;
            _tabBar.ItemSelected += OnTabBarItemSelected;
        }

        private void OnTabBarItemSelected(object sender, UITabBarItemEventArgs e)
        {
            var index = (int)e.Item.Tag;
            var page = VirtualView;
            if (page == null || index < 0 || index >= page.Children.Count)
            {
                Console.WriteLine("OnTabBarItemSelected: Index out of bounds or page is null.");
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
                if (page == null || _tabBar == null)
                {
                    Console.WriteLine("UpdateTabViewState: VirtualView or _tabBar is null.");
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
                    var previousItem = _tabBar.Items.ElementAtOrDefault(_position);
                    var previousTab = ((List<Foundation.TabItem>)VirtualView.ItemsSource)?[_position];

                    if (previousItem != null && previousTab != null)
                    {
                        previousItem.Image = UIImage.FromBundle(previousTab.ImageSource.Normal)
                                                   .ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
                        previousItem.SelectedImage = UIImage.FromBundle(previousTab.ImageSource.Normal)
                                                      .ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
                    }
                }

                var currentItem = _tabBar.Items.ElementAtOrDefault(newPosition);
                var currentTab = ((List<Foundation.TabItem>)VirtualView.ItemsSource)?[newPosition];

                if (currentItem != null && currentTab != null)
                {
                    currentItem.Image = UIImage.FromBundle(currentTab.ImageSource.Focused)
                                               .ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
                    currentItem.SelectedImage = UIImage.FromBundle(currentTab.ImageSource.Focused)
                                                   .ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
                }

                _position = newPosition;

                _tabBar.SetNeedsLayout();
                _tabBar.LayoutIfNeeded();

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

            _contentView.Subviews.ToList().ForEach(view => view.RemoveFromSuperview());

            var currentPage = VirtualView.CurrentPage;
            if (currentPage != null)
            {
                var platformView = currentPage.ToPlatform(MauiContext);
                platformView.Frame = _contentView.Bounds;
                _contentView.AddSubview(platformView);
            }
        }

        private void SetupContainer()
        {
            if (_tabBar == null || _containerView == null || _contentView == null)
            {
                Console.WriteLine("SetupContainer: One or more views are null.");
                return;
            }

            _tabBar.TranslatesAutoresizingMaskIntoConstraints = false;
            _contentView.TranslatesAutoresizingMaskIntoConstraints = false;

            NSLayoutConstraint.ActivateConstraints(new[]
            {
                _tabBar.LeadingAnchor.ConstraintEqualTo(_containerView.LeadingAnchor),
                _tabBar.TrailingAnchor.ConstraintEqualTo(_containerView.TrailingAnchor),
                _tabBar.BottomAnchor.ConstraintEqualTo(_containerView.BottomAnchor),
                _tabBar.HeightAnchor.ConstraintEqualTo(90),

                _contentView.LeadingAnchor.ConstraintEqualTo(_containerView.LeadingAnchor),
                _contentView.TrailingAnchor.ConstraintEqualTo(_containerView.TrailingAnchor),
                _contentView.TopAnchor.ConstraintEqualTo(_containerView.TopAnchor),
                _contentView.BottomAnchor.ConstraintEqualTo(_tabBar.TopAnchor)
            });

            Console.WriteLine($"ContainerView Frame: {_containerView.Frame}");
            Console.WriteLine($"ContentView Frame: {_contentView.Frame}");
            Console.WriteLine($"TabBar Frame: {_tabBar.Frame}");

            _containerView.SetNeedsLayout();
            _containerView.LayoutIfNeeded();
        }
    }

}

