using System;
using System.Windows.Input;

namespace TabbarHandlerIssue.Foundation
{
    public class TabItem
    {
        public string Title { get; set; }
        public ImageSourceStateList ImageSource { get; set; }
    }

    public class TabbedPage : Microsoft.Maui.Controls.TabbedPage
    {
        public static readonly BindableProperty ActionTappedCommandProperty =
            BindableProperty.Create(
                nameof(ActionTappedCommand),
                typeof(ICommand),
                typeof(TabbedPage));

        public ICommand ActionTappedCommand
        {
            get => (ICommand)GetValue(ActionTappedCommandProperty);
            set => SetValue(ActionTappedCommandProperty, value);
        }

        public virtual bool WillAllowNavigate(int index)
        {
            return true;
        }
    }
}

