using Foundation;

namespace TabbarHandlerIssue.Foundation
{
    public class BaseNavigationPage : NavigationPage
    {
        bool _isModal;
        public bool IsModal
        {
            get => _isModal;
            set
            {
                _isModal = value;
                if (RootPage != null
                    && RootPage is BasePage b)
                {
                    b.IsModal = value;
                }
            }
        }

        public BaseNavigationPage()
        {
        }

        public BaseNavigationPage(Page root) : base(root)
        {
            if (root is BasePage p)
            {
                p.IsRoot = true;
            }
        }
    }
}
