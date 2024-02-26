# MAUI Repro sample template

- could not repro

    -   all tests - 0%-3%

    -   manual too

-   1000 samples - approx 1 sec each

-   tested

    -   2 macs

        -   M2
    
        -   x86 i9

    -   on

        -   emulators

        -   pixel5 device

            I was not able




### Mac M2 pixel5 net8.0 

- crash during start (needs investigation)

    - workaround - nuke bin/ obj/

```
dotnet build \
    ./net8.0/ProjectsStructureTemplate.AppMAUI.DemoSample/ProjectsStructureTemplate.AppMAUI.DemoSample.csproj \
    -t:run \
    -f:net-8.0-android
```

```
adb shell top -n 1000 | grep "com.companyname" > pixel5--net8.0.top.processor.log
```

Could not redirect output to file. Redirecting hangs.

```
adb shell top -n 1000
```

Does not even list tested app

```
adb shell top -n 1000 | grep "com.companyname"                                  
```

shows around 3% (constant)

```
20790 u0_a56       10 -10  14G 227M 121M S  1.3   3.0   0:04.22 com.companyname+
20790 u0_a56       10 -10  14G 227M 121M S  1.3   3.0   0:04.22 com.companyname+
```


### Mac M2 emulator net8.0 - OK

```
dotnet build \
    ./net8.0/ProjectsStructureTemplate.AppMAUI.DemoSample/ProjectsStructureTemplate.AppMAUI.DemoSample.csproj \
    -t:run \
    -f:net-8.0-android
```

```
adb shell top -n 1000 | grep "com.companyname" > emulator-2--net8.0.top.processor.log
```

### Mac M2 emulator net7.0 - OK

```
dotnet build \
    ./net7.0/ProjectsStructureTemplate.AppMAUI.DemoSample/ProjectsStructureTemplate.AppMAUI.DemoSample.csproj \
    -t:run \
    -f:net-7.0-android
```

```
adb shell top -n 1000 | grep "com.companyname" > emulator-2--net7.0.top.processor.log
```

