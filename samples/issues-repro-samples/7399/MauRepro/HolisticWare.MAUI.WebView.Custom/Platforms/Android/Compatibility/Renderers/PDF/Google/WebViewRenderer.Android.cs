using System;
using System.Net;

using Android.Content;

using Microsoft.Maui;
using Microsoft.Maui.Platform.Android;

//[assembly: 
//    ExportRenderer
//        (
//            typeof(HolisticWare.XamarinForms.WebView.PDF.Google.WebView),
//            typeof(HolisticWare.XamarinForms.WebView.PDF.Google.WebViewRenderer)
//        )
//]
namespace HolisticWare.XamarinForms.WebView.PDF.Google
{
    public class WebViewRenderer : Microsoft.Maui.Platform.Android.WebViewRenderer
    {
        private WebViewRenderer web_view;

        public WebViewRenderer(Context context) : base(context)
        {
        }

        protected override
            void
                                        OnElementChanged
                                            (
                                                ElementChangedEventArgs<Microsoft.Maui.Controls.WebView> e
                                            )
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                return;
            }

            web_view = Element as HolisticWare.XamarinForms.WebView.PDF.Google.WebView;

            Control.Settings.JavaScriptEnabled = true;
            Control.Settings.AllowUniversalAccessFromFileURLs = true;

            if (web_view.Uri != null)
            {
                string url_pdf = WebUtility.UrlEncode(web_view.Uri);
                string url = $"https://drive.google.com/viewerng/viewer?url={url_pdf}";

                Control.LoadUrl(url);
            }

            return;
        }

        protected override
            void
                                        OnElementPropertyChanged
                                            (
                                                object sender, 
                                                PropertyChangedEventArgs e
                                            )
        {
            if (sender is null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            base.OnElementPropertyChanged(sender, e);

            if
                (
                    e.PropertyName == nameof(GoogleDriveViewerWebView.Uri)
                    &&
                    web_view.Uri != null
                )
            {
                string url_pdf = WebUtility.UrlEncode(web_view.Uri);
                string url = $"https://drive.google.com/viewerng/viewer?url={url_pdf}";

                Control.LoadUrl(url);
            }

            return;
        }
    }
}