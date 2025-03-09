using Microsoft.Maui.Platform;
namespace SimpleSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ModifyEntry();
        }


        private void Entry_Completed(object sender, EventArgs e)
        {

        }

        void ModifyEntry()
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.ViewAttachedToWindow += (sender, args) =>
                {

                    handler.PlatformView.UpdateReturnType(view);

                };
#endif
            });
        }

    }
}

