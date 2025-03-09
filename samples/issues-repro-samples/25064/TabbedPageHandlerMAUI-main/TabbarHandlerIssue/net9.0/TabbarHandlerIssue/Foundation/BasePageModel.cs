using System.Reactive.Disposables;
using Core.Http;
using PropertyChanged;

namespace TabbarHandlerIssue.Foundation
{
    [AddINotifyPropertyChangedInterface]
    public abstract class BasePageModel : BaseViewModel,
                                 IAlertHandler
    {
        protected internal INavigation Navigation { get; set; }
        protected internal IAlertHandler AlertHandler { get; set; }

        #region Life-cycle methods

        protected virtual internal void OnAppearing()
        {
        }

        protected virtual internal void OnDisappearing()
        {
            Dispose();
        }

        #endregion

        protected void HandleException(Exception e)
        {
            string message = e.Message;

            if (e is ServerNotFoundException)
            {
                message = "Not found";
            }
            else if (e is ConnectionException)
            {
                message = "noConnection";
            }
            else if (e is HttpException http
                     && http.StatusCode == 500)
            {
                message = "serverUnhandledRequest";
            }
            else if (e is HttpException httpInvalid
                     && httpInvalid.StatusCode == 401)
            {
                message = "";
            }
            else if (e is HttpException exception
                     && !string.IsNullOrEmpty(message?.Trim()) && message.ToLower().Contains("not found"))
            {
                message = "";
                DisplayAlert(null, "not found", "OK");
            }
            else if (e is HttpException httpException
                  && !string.IsNullOrEmpty(message?.Trim()) && message.ToLower().Contains("not found"))
            {
                message = "";
                DisplayAlert(null, "not found", "OK");
            }

            if (!string.IsNullOrEmpty(message?.Trim()))
            {
                DisplayAlert(null, message, "OK");
            }
        }


        public Task<string> DisplayActionSheet(string title,
                                               string cancel,
                                              string destruction,
                                               params string[] buttons)
        {
            return AlertHandler.DisplayActionSheet(title, cancel, destruction, buttons);
        }

        public Task DisplayAlert(string title, string message, string cancel)
        {
            return AlertHandler.DisplayAlert(title, message, cancel);
        }

        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return AlertHandler.DisplayAlert(title, message, accept, cancel);
        }

    }

    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : BindableObject, IDisposable
    {
        public bool IsBusy { get; set; }

        protected CompositeDisposable DisposableBag { get; } = new CompositeDisposable();

        protected internal TabbarHandlerIssue.Http.IoC.IContainer Container => TabbarHandlerIssue.Http.IoC.Container.Current;

        public virtual void Dispose()
        {
            DisposableBag.Clear();
        }
    }
}
