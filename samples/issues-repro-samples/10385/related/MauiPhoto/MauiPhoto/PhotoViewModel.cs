using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiPhoto
{
    public partial class PhotoViewModel: BaseViewModel
    {
   
        public string localFilePath { get; set; } = null;

        [ObservableProperty]
        ImageSource immagine;


        [RelayCommand]
        async Task TakePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
                if (photo != null)
                {
                    localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);
                    await sourceStream.CopyToAsync(localFileStream);
                    Immagine = ImageSource.FromFile(localFilePath);

                }
            }

        }


    
    }
}
