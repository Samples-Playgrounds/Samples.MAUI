using Xamarin.Forms;

namespace HolisticWare.XamarinForms.WebView.PDF
{
    public class WebViewPDF : Xamarin.Forms.WebView
    {
        public static readonly
            Xamarin.Forms.BindableProperty
                                        UriProperty =
                                                Xamarin.Forms.BindableProperty.Create
                                                                                (
                                                                                    nameof(Uri),
                                                                                    typeof(string),
                                                                                    typeof(WebViewPDF),
                                                                                    default(string)
                                                                                );

        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }
    }
}