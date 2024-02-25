

```
dotnet build \
    net8.0/ProjectsStructureTemplate.AppMAUI.DemoSample/ProjectsStructureTemplate.AppMAUI.DemoSample.csproj \ -t:run \
    -f:net8.0-android
```

```
/usr/local/share/dotnet/packs/Microsoft.Android.Sdk.Darwin/34.0.79/tools/Xamarin.Android.Common.Debugging.targets(678,5): error XA0129: Error deploying 'files/.__override__/System.Runtime.InteropServices.JavaScript.dll'. [./20684/AppRepro/net8.0/ProjectsStructureTemplate.AppMAUI.DemoSample/ProjectsStructureTemplate.AppMAUI.DemoSample.csproj::TargetFramework=net8.0-android]
/usr/local/share/dotnet/packs/Microsoft.Android.Sdk.Darwin/34.0.79/tools/Xamarin.Android.Common.Debugging.targets(678,5): error XA0129: Please set the 'EmbedAssembliesIntoApk' MSBuild property to 'true' to disable Fast Deployment in the Visual Studio project property pages, or edit the project file in a text editor. [./20684/AppRepro/net8.0/ProjectsStructureTemplate.AppMAUI.DemoSample/ProjectsStructureTemplate.AppMAUI.DemoSample.csproj::TargetFramework=net8.0-android]

```

