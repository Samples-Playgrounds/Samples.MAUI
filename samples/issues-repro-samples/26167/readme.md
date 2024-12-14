# 26167

readme.md




*   https://github.com/dotnet/maui/issues/26167

*   https://github.com/jfversluis/MauiBase64ImageSample

*   https://github.com/mapsouza/FileNotFoundImage

*   https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/storage/file-system-helpers?view=net-maui-9.0&tabs=android#bundled-files

## Test matrix

| sample                 | TFM                  | Status      |
|------------------------|----------------------|-------------|
| MauiBase64ImageSample  |`net9.0-maccatalyst`  |   OK        |
| MauiBase64ImageSample  |`net9.0-ios        `  |   OK        |
| MauiBase64ImageSample  |`net9.0-android`      |   OK        |
| MauiBase64ImageSample  |`net8.0-maccatalyst`  |   OK        |
| MauiBase64ImageSample  |`net8.0-ios        `  |   OK        |
| MauiBase64ImageSample  |`net8.0-android`      |   OK        |
| FileNotFoundImage      |`net9.0-maccatalyst`  |   OK        |
| FileNotFoundImage      |`net9.0-ios        `  |   OK        |
| FileNotFoundImage      |`net9.0-android`      |   Crash     |
| FileNotFoundImage      |`net8.0-maccatalyst`  |   OK        |
| FileNotFoundImage      |`net8.0-ios        `  |   OK        |
| FileNotFoundImage      |`net8.0-android`      |   Crash     |
|                        |                      |             |
| FileNotFoundImageFixed |`net9.0-maccatalyst`  |   OK        |
| FileNotFoundImageFixed |`net9.0-ios        `  |   OK        |
| FileNotFoundImageFixed |`net9.0-android`      |   OK        |
| FileNotFoundImageFixed |`net8.0-maccatalyst`  |   OK        |
| FileNotFoundImageFixed |`net8.0-ios        `  |   OK        |
| FileNotFoundImageFixed |`net8.0-android`      |   OK        |



## Initialize 

```
mkdir net8.0
mkdir net9.0

dotnet new \
    globaljson \
        --sdk-version 8.0.404 \
        --output net8.0\


dotnet new \
    globaljson \
        --sdk-version 9.0.100 \
        --output net9.0\

dotnet new \
    maui \
        --framework net8.0 \
        --output net8.0/AppMAUI

dotnet new \
    maui \
        --framework net9.0 \
        --output net9.0/AppMAUI

dotnet new \
    sln \
        --output net8.0/ \
        --name Repro

dotnet new \
    sln \
        --output net9.0/ \
        --name Repro

```


## Assets

*   https://stackoverflow.com/questions/76674724/maui-android-how-to-read-asset-files

```csharp
public async Task CopyFileToAppDataDirectory(string filename)
{
    // Open the source file
    using Stream inputStream = await FileSystem.Current.OpenAppPackageFileAsync(filename);

    // Create an output filename
    string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, filename);

    // Copy the file to the AppDataDirectory
    using FileStream outputStream = File.Create(targetFile);
    await inputStream.CopyToAsync(outputStream);
}
```

https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/storage/file-system-helpers

https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/single-project#resource-files

https://stackoverflow.com/questions/70442638/how-do-i-read-a-deployed-file-in-maui-xamarin-on-android

https://stackoverflow.com/questions/74908192/net-maui-list-assets-under-resources-raw-folder
