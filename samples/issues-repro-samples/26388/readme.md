# 26388

readme.md

https://github.com/dotnet/maui/issues/26388

Net 9 Android - StatusBar Color overriden on modal pages #26388

 dotnet build \
    net8.0/StatusBarIssue-Net9-main/TestStatusBar/TestStatusBar.csproj \
    -f:net8.0-maccatalyst


    /Users/Shared/Projects/d/Samples-Playgrounds/gh/MAUI/samples/issues-repro-samples/26388/net8.0/StatusBarIssue-Net9-main/TestStatusBar/Platforms/MacCatalyst/AppDelegate.cs(6,32): error CS0246: The type or namespace name 'MauiUIApplicationDelegate' could not be found (are you missing a using directive or an assembly reference?)

export TFM=net8.0
dotnet build \
    $TFM/StatusBarIssue-Net9-main/TestStatusBar/TestStatusBar.csproj \
    -f:$TFM-ios \
    -t:run

dotnet build \
    $TFM/StatusBarIssue-Net9-main/TestStatusBar/TestStatusBar.csproj \
    -f:$TFM-maccatalyst \
    -t:run

dotnet build \
    $TFM/StatusBarIssue-Net9-main/TestStatusBar/TestStatusBar.csproj \
    -f:$TFM-android \
    -t:run
