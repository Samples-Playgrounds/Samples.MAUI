using Foundation;

namespace TabbarHandlerIssue.Foundation
{
    public class NavigationDelegate : INavigation
    {
        public bool IsActive { get; set; }

        public IReadOnlyList<Page> ModalStack => _navigation.ModalStack;
        public IReadOnlyList<Page> NavigationStack => _navigation.NavigationStack;

        readonly INavigation _navigation;

        public NavigationDelegate(INavigation navigation)
        {
            _navigation = navigation;
        }

        public void InsertPageBefore(Page page, Page before)
        {
            if (WillAllowNavigation())
            {
                _navigation.InsertPageBefore(page, before);
            }
        }

        public Task<Page> PopAsync()
        {
            if (WillAllowNavigation())
            {
                return _navigation.PopAsync();
            }
            return Task.FromResult<Page>(null);
        }

        public Task<Page> PopAsync(bool animated)
        {
            if (WillAllowNavigation())
            {
                return _navigation.PopAsync(animated);
            }
            return Task.FromResult<Page>(null);
        }

        public Task<Page> PopModalAsync()
        {
            if (WillAllowNavigation())
            {
                return _navigation.PopModalAsync();
            }
            return Task.FromResult<Page>(null);
        }

        public Task<Page> PopModalAsync(bool animated)
        {
            if (WillAllowNavigation())
            {
                return _navigation.PopModalAsync(animated);
            }
            return Task.FromResult<Page>(null);
        }

        public Task PopToRootAsync()
        {
            if (WillAllowNavigation())
            {
                return _navigation.PopModalAsync();
            }
            return Task.CompletedTask;
        }

        public Task PopToRootAsync(bool animated)
        {
            if (WillAllowNavigation())
            {
                return _navigation.PopToRootAsync(animated);
            }
            return Task.CompletedTask;
        }

        public Task PushAsync(Page page)
        {
            if (WillAllowNavigation())
            {
                if (page is BasePage b)
                {
                    b.IsRoot = false;
                }
                return _navigation.PushAsync(page);
            }
            return Task.CompletedTask;
        }

        public Task PushAsync(Page page, bool animated)
        {
            if (WillAllowNavigation())
            {
                if (page is BasePage b)
                {
                    b.IsRoot = false;
                }
                return _navigation.PushAsync(page, animated);
            }
            return Task.CompletedTask;
        }

        public Task PushModalAsync(Page page)
        {
            if (WillAllowNavigation())
            {
                if (page is BasePage b)
                {
                    b.IsModal = true;
                }
                else if (page is BaseNavigationPage n)
                {
                    n.IsModal = true;
                }
                return _navigation.PushModalAsync(page);
            }
            return Task.CompletedTask;
        }

        public Task PushModalAsync(Page page, bool animated)
        {
            if (WillAllowNavigation())
            {
                if (page is BasePage b)
                {
                    b.IsModal = true;
                }
                else if (page is BaseNavigationPage n)
                {
                    n.IsModal = true;
                }
                return _navigation.PushModalAsync(page, animated);
            }
            return Task.CompletedTask;
        }

        public void RemovePage(Page page)
        {
            _navigation.RemovePage(page);
        }

        bool WillAllowNavigation()
        {
            if (IsActive)
            {
                IsActive = false;
                return true;
            }
            return false;
        }
    }
}


