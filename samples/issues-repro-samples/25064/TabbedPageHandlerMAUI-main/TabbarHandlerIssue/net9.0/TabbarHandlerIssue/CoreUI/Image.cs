namespace TabbarHandlerIssue.CoreUI
{
    public class Image : Microsoft.Maui.Controls.Image
    {
        #region Bindable Properties

        public static readonly BindableProperty ResizableSourceProperty = BindableProperty.Create(
          nameof(ResizableSource),
          typeof(FileImageSource),
          typeof(Image),
          default(FileImageSource));

        public static readonly BindableProperty EdgeInsetsProperty = BindableProperty.Create(
          nameof(EdgeInsets),
          typeof(EdgeInsets),
          typeof(Entry),
          default(EdgeInsets));

        public static readonly BindableProperty ResizeModeProperty = BindableProperty.Create(
          nameof(ResizeMode),
          typeof(ResizeMode),
          typeof(Entry),
          default(ResizeMode));

        public FileImageSource ResizableSource
        {
            get { return (FileImageSource)GetValue(ResizableSourceProperty); }
            set { SetValue(ResizableSourceProperty, value); }
        }

        public EdgeInsets EdgeInsets
        {
            get { return (EdgeInsets)GetValue(EdgeInsetsProperty); }
            set { SetValue(EdgeInsetsProperty, value); }
        }

        public ResizeMode ResizeMode
        {
            get { return (ResizeMode)GetValue(ResizeModeProperty); }
            set { SetValue(ResizeModeProperty, value); }
        }

        #endregion
    }
}
