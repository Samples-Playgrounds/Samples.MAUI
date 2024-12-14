# MAUI App

readme.md

*   ./src/Controls/samples/Controls.Sample/Maui.Controls.Sample.csproj

    https://github.com/dotnet/maui/blob/main/src/Controls/samples/Controls.Sample/Maui.Controls.Sample.csproj#L65-L74

*   

    https://github.com/dotnet/maui/blob/main/src/Controls/samples/Controls.Sample.UITests/Controls.Sample.UITests.csproj#L26-L35

*   

    https://github.com/dotnet/maui/blob/main/src/Essentials/samples/Samples/Essentials.Sample.csproj#L40-L45

    https://github.com/dotnet/maui/tree/main/src/BlazorWebView/samples




## 

*   https://github.com/dotnet/maui/tree/main/src/Controls/samples

*   https://github.com/dotnet/maui/tree/main/src/Essentials/samples

    *   https://github.com/dotnet/maui/tree/main/src/Essentials/samples/Sample.Server.WebAuthenticator



```
dev_dotnet_folders_nuke \
&& \
dotnet build \
    AppMAUI.ProjectReferrences/AppMAUI.ProjectReferrences.csproj \
    -t:run \
    -f:net8.0-maccatalyst \
&& \
dotnet build \
    AppMAUI.Blazor.ProjectReferrences/AppMAUI.Blazor.ProjectReferrences.csproj \
    -t:run \
    -f:net8.0-ios \
```