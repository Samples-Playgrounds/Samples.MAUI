using System;
using System.Net;

// migration to MAUI not needed using Xamarin.Forms;
// migration to MAUI not needed using Xamarin.Forms.Platform.Android;

using HolisticWare.XamarinForms.WebView.PDF;
using HolisticWare.XamarinForms.WebView.PDF.Platforms.Android;


// migration to MAUI not needed [assembly: ExportRenderer(typeof(WebViewPDF), typeof(WebViewPDFRenderer))]
namespace HolisticWare.XamarinForms.WebView.PDF.Platforms.Android
{
    public class WebViewPDFRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<global::Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                WebViewPDF customWebView = Element as WebViewPDF;
                Control.Settings.AllowUniversalAccessFromFileURLs = true;
                Control.LoadUrl
                            (
                                string.Format
                                        (
                                            "file:///android_asset/pdfjs/web/viewer.html?file={0}",
                                            string.Format
                                                        (
                                                            "file:///android_asset/Content/{0}",
                                                            WebUtility.UrlEncode(customWebView.Uri)
                                                        )
                                        )
                                );
            }
        }
    }
}

