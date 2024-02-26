# MAUI Repro sample template




```
dotnet build \
    ./net8.0/ProjectsStructureTemplate.AppMAUI.DemoSample/ProjectsStructureTemplate.AppMAUI.DemoSample.csproj \
    -t:run \
    -f:net-8.0-android
```

```
adb shell top -n 1000 | grep "com.companyname" > emulator-2--net8.0.top.processor.log
```

```
dotnet build \
    ./net7.0/ProjectsStructureTemplate.AppMAUI.DemoSample/ProjectsStructureTemplate.AppMAUI.DemoSample.csproj \
    -t:run \
    -f:net-8.0-android
```

```
adb shell top -n 1000 | grep "com.companyname" > emulator-2--net8.0.top.processor.log
```

