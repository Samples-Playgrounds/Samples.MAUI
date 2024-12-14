using System;

namespace Sample.Issue_10385.MediaPickerCrash.Views;

public partial class MediaPickerDemos : ContentPage
{
    public MediaPickerDemos()
    {
        InitializeComponent();

        /*
        <ContentPage.BindingContext>
            <view_models:MediaPickerDemos />
        </ContentPage.BindingContext>
        */
        // BindingContext = typeof(ViewModels.MediaPickerDemos);

        return;
    }

    private void button_pick_photo_Clicked(object sender, EventArgs e)
    {
        FileResult file_result_photo =
                                        // await
                                        MediaPicker.Default.PickPhotoAsync()
                                       .Result
                                        ;

        if (file_result_photo != null)
        {
            var stream =
                            // await
                            file_result_photo.OpenReadAsync()
                            .Result
                            ;
            ImagePickedOrCaptured.Source = ImageSource.FromStream(() => stream);
        }

        return;
    }


}

