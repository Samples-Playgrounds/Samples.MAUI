

https://github.com/dotnet/maui/issues/16980


```
dotnet build \
    16980/begin/net7.0/EntryClearButtonIssue-main/EntrySample/EntrySample/EntrySample.csproj \
        -f:net7.0-android \
        -bl \
        -v: diagnostic \
        -flp:v=diagnostic;logfile=appmaui-build.log

dotnet build \
    16980/begin/net7.0/EntryClearButtonIssue-main/EntrySample/EntrySample/EntrySample.csproj \
        -f:net7.0-android \
        -t:run
```

```
dotnet build \
    16980/begin/net8.0/EntryClearButtonIssue-main/EntrySample/EntrySample/EntrySample.csproj \
        -f:net8.0-android \
        -bl \
        -v: diagnostic \
        -flp:v=diagnostic;logfile=appmaui-build.log

dotnet build \
    16980/begin/net8.0/EntryClearButtonIssue-main/EntrySample/EntrySample/EntrySample.csproj \
        -f:net8.0-android \
        -t:run
```


```
dotnet build \
    14620/begin/net8.0/MauiApp22/MauiApp22.csproj \
        -f:net8.0-android \
        -bl \
        -v: diagnostic \
        -flp:v=diagnostic;logfile=appmaui-build.log

dotnet build \
    14620/begin/net8.0/MauiApp22/MauiApp22.csproj \
        -f:net8.0-android \
        -t:run
```


```
dotnet build \
    14620/begin/net7.0/MauiApp22/MauiApp22.csproj \
        -f:net7.0-android \
        -bl \
        -v: diagnostic \
        -flp:v=diagnostic;logfile=appmaui-build.log

dotnet build \
    14620/begin/net7.0/MauiApp22/MauiApp22.csproj \
        -f:net7.0-android \
        -t:run
```
