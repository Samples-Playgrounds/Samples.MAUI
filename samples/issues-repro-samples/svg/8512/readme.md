#


```
dotnet build \
    net6.0/PathGeometryRenderBugMauiApp/PathGeometryRenderBugMauiApp.csproj \
    -f:net6.0-android \
    -t:Run
```

```
/usr/local/share/dotnet/sdk/8.0.100-preview.7.23376.3/Sdks/Microsoft.NET.Sdk/targets/Microsoft.NET.EolTargetFrameworks.targets(35,5): error NETSDK1202: The workload 'android' is out of support and will not receive security updates in the future. Please refer to https://aka.ms/maui-support-policy for more information about the support policy. [./8512/net6.0/PathGeometryRenderBugMauiApp/PathGeometryRenderBugMauiApp.csproj::TargetFramework=net6.0-android]
/usr/local/share/dotnet/sdk/8.0.100-preview.7.23376.3/Sdks/Microsoft.NET.Sdk/targets/Microsoft.NET.Sdk.ImportWorkloads.targets(38,5): error NETSDK1147: To build this project, the following workloads must be installed: wasm-tools-net6 [./8512/net6.0/PathGeometryRenderBugMauiApp/PathGeometryRenderBugMauiApp.csproj::TargetFramework=net6.0-ios]
/usr/local/share/dotnet/sdk/8.0.100-preview.7.23376.3/Sdks/Microsoft.NET.Sdk/targets/Microsoft.NET.Sdk.ImportWorkloads.targets(38,5): error NETSDK1147: To install these workloads, run the following command: dotnet workload restore [./8512/net6.0/PathGeometryRenderBugMauiApp/PathGeometryRenderBugMauiApp.csproj::TargetFramework=net6.0-ios]
    0 Warning(s)
    2 Error(s)

```



```
dotnet build \
    net7.0/PathGeometryRenderBugMauiApp/PathGeometryRenderBugMauiApp.csproj \
    -f:net7.0-android \
    -t:Run
```

