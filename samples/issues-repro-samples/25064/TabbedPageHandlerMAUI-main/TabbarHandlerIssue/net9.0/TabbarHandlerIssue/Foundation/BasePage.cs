using TabbarHandlerIssue.Foundation;

namespace Foundation
{
    public class BasePage : ContentPage, IAlertHandler
    {
        #region Bindable property

        public static readonly BindableProperty IsRootProperty = BindableProperty.Create(
          nameof(IsRoot),
          typeof(bool),
          typeof(NavigationBar),
          true
        );

        public static readonly BindableProperty IsModalProperty = BindableProperty.Create(
          nameof(IsModal),
          typeof(bool),
          typeof(NavigationBar),
          false
        );

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

        #endregion

        BasePageModel _pageModel;

        protected NavigationDelegate NavigationDelegate { get; private set; }

        public BasePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationDelegate = new NavigationDelegate(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_pageModel != null)
            {
                NavigationDelegate.IsActive = true;
                _pageModel.OnAppearing();
            }
        }

        protected override void OnDisappearing()
        {
            if (_pageModel != null)
            {
                _pageModel.OnDisappearing();
            }
            base.OnDisappearing();
        }

        protected T SetPageModel<T>() where T : class
        {
            T type = TabbarHandlerIssue.Http.IoC.Container.Current.Construct<T>();
            BindingContext = type;

            if (BindingContext is BasePageModel model)
            {
                model.AlertHandler = this;
                model.Navigation = NavigationDelegate;
                _pageModel = model;
            }

            return type;
        }

        public T GetPageModel<T>() where T : class
        {
            return BindingContext as T;
        }
    }
}
