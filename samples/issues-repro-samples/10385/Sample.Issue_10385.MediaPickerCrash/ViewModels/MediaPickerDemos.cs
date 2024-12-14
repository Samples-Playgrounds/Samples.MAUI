using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Sample.Issue_10385.MediaPickerCrash.ViewModels;

public class MediaPickerDemos : ObservableObject, IQueryAttributable
{
    public MediaPickerDemos()
    {
        ImageSourcePickedOrCaptured = "dotnet_bot.png";

        CommandPhotoPick = new AsyncRelayCommand(CommandPhotoPickImplementationAsync);

        return;
    }

    public ICommand CommandPhotoPick
    {
        get;
        private set;
    }

    public ImageSource ImageSourcePickedOrCaptured
    {
        get;
        set;
    }

    Stream stream = null;

    public async Task CommandPhotoPickImplementationAsync()
    {
        FileResult photoSelected = await MediaPicker.Default.PickPhotoAsync();

        if (photoSelected != null)
        {
            stream = await photoSelected.OpenReadAsync();

            ImageSourcePickedOrCaptured = ImageSource.FromStream
                                                        (
                                                            () => stream
                                                        );

            OnPropertyChanged("ImageSourcePickedOrCaptured");
        }
    }


    public async Task PhotoCaptureAsync()
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                // save the file into local storage
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);

                await sourceStream.CopyToAsync(localFileStream);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// When a page, or the binding context of a page, implements this interface,
    /// the query string parameters used in navigation are passed to the ApplyQueryAttributes method
    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("load"))
        {
            //_note = Models.Note.Load(query["load"].ToString());
            //RefreshProperties();
        }

        return;
    }
}

