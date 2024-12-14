using System.IO;
using System.Net;

using Foundation;
using UIKit;

// migration to MAUI not needed using Xamarin.Forms;
// migration to MAUI not needed using Xamarin.Forms.Platform.Windows;

using HolisticWare.XamarinForms.WebView.PDF;
using HolisticWare.XamarinForms.WebView.PDF.Platforms.Windows;

// migration to MAUI not needed [assembly: ExportRenderer(typeof(WebViewPDF), typeof(WebViewPDFRenderer))]
namespace HolisticWare.XamarinForms.WebView.PDF.Platforms.Windows
{
    public class WebViewPDFRenderer : ViewRenderer<WebViewPDF, UIWebView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<WebViewPDFRenderer> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(new UIWebView());
            }
            if (e.OldElement != null)
            {
                // Cleanup
            }
            if (e.NewElement != null)
            {
                WebViewPDF customWebView = Element as WebViewPDF;
                string fileName = Path.Combine(NSBundle.MainBundle.BundlePath, string.Format("Content/{0}", WebUtility.UrlEncode(customWebView.Uri)));
                Control.LoadRequest(new NSUrlRequest(new NSUrl(fileName, false)));
                Control.ScalesPageToFit = true;
            }
        }
    }
}