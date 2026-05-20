# 20250509

*   https://learn.microsoft.com/en-us/dotnet/maui/get-started/installation?view=net-maui-9.0&tabs=visual-studio-code-experimental#follow-the-steps-in-the-walkthrough


## iOS/MaciOS

*   https://discussions.apple.com/thread/254132081?sortBy=rank

```bash
xcrun simctl --set previews delete all
xcrun simctl delete all

sudo xcode-select --reset

# List all simulators
xcrun simctl list devices

# Remove only unavailable simulators
xcrun simctl delete unavailable

# Remove specific simulator
xcrun simctl delete "iPhone 11 Pro Max"

# Reset all simulator content and settings
xcrun simctl erase all

# List simulator runtimes
xcrun simctl runtime list

# delete unavailble runtimes e.g. removes iOS 15 if you run Xcode 15
xcrun simctl runtime delete unavailable 

sudo /Developer/Library/uninstall-devtools --mode=all

rm -fr \
    "$HOME/Library/Caches/com.apple.dt.Xcode" \
    "$HOME$/Library/Developer/Xcode/DerivedData" \
    "$HOME$/Library/Developer/Xcode/Archives"

sudo \
    rm -fr \
        "/Applications/Xcode.app" \
        "/Applications/Developer.app" \
        "$HOME/Library/Application Support/Xcode" \
        "$HOME/Library/Developer" \
        /Library/Developer/CoreSimulator/ \

sudo \
    rm -fr \
        /Library/Developer/CommandLineTools/ \
        /Library/Developer/CoreDevice/ \
        /Library/Developer/DeveloperDiskImages/ \
        /Library/Developer/DeviceKit/ \


#    /Library/Developer/PrivateFrameworks/ \

```

## Android

```
rm -fr \
    $HOME/Library/Android/sdk/ \
    $HOME/android-toolchain/ \


rm -fr \
    $HOME/.android \

rm -fr \
    "$HOME/Applications/Android Studio.app/" \

```

```
export JAVA_HOME=/Library/Java/JavaVirtualMachines/microsoft-17.jdk/Contents/Home
cd $HOME/Library/Android/sdk/cmdline-tools/12.0/bin/
./sdkmanager "system-images;android-36;google_apis;arm64-v8a"
cd -
```



## .NET

https://gist.github.com/justinyoo/68c11fa00480fa15d38f7288815c6ba5

```
sudo dotnet nuget locals all --clear

dotnet sdk \
    uninstall

dotnet runtime \
    uninstall

sudo \
    rm -fr \
        /usr/local/share/dotnet/sdk/* \
        /usr/local/share/dotnet/sdk-manifests/* \

sudo \
    rm -fr \
        /usr/local/share/dotnet/shared/Microsoft.NETCore.App/* \
        /usr/local/share/dotnet/shared/Microsoft.AspNetCore.App/* \

rm -fr \
    $HOME/.dotnet/ \
    $HOME/.mono/ \
    $HOME/.nuget/ \
    $HOME/.omnisharp/ \
    $HOME/.aspnet/ \
    $HOME/Library/Caches/XamarinBuildDownload/ \
    $HOME/Library/Caches/dotnet-android/ \
    $HOME/Library/Caches/dotnet-script/ \
    $HOME/Library/Caches/dotnet-/ \

        
rm -fr \        
    $HOME/.cache/csharpier/* \
    $HOME/.cache/powershell/* \

        $HOME/.templateengine/
```


```
6.0.428 [/usr/local/share/dotnet/sdk]
8.0.114 [/usr/local/share/dotnet/sdk]
8.0.115 [/usr/local/share/dotnet/sdk]
8.0.310 [/usr/local/share/dotnet/sdk]
8.0.311 [/usr/local/share/dotnet/sdk]
8.0.407 [/usr/local/share/dotnet/sdk]
8.0.408 [/usr/local/share/dotnet/sdk]
9.0.104 [/usr/local/share/dotnet/sdk]
9.0.105 [/usr/local/share/dotnet/sdk]
9.0.202 [/usr/local/share/dotnet/sdk]
9.0.203 [/usr/local/share/dotnet/sdk]
10.0.100-preview.2.25164.34 [/usr/local/share/dotnet/sdk]
10.0.100-preview.3.25201.16 [/usr/local/share/dotnet/sdk]
```


## Issues

1.  Android

```
An error occurred trying to install Android SDK. User does not have permission to write to the directory: 
    $HOME/Library/Android/sdk/cmdline-tools/12.0
```