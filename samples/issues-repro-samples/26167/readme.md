# 26167

readme.md

*   https://github.com/dotnet/maui/issues/26167

*   https://github.com/jfversluis/MauiBase64ImageSample

*   https://github.com/mapsouza/FileNotFoundImage

*   https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/storage/file-system-helpers?view=net-maui-9.0&tabs=android#bundled-files

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


