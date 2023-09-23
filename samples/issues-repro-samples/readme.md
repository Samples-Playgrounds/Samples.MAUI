# MAUI Repro samples

readme.md

*   https://github.com/dotnet/maui/blob/main/.github/DEVELOPMENT.md

*   https://github.com/dotnet/maui/blob/main/docs/TriageProcess.md

*   Profiling

    *   https://aka.ms/profile-maui

        *   https://github.com/dotnet/maui/wiki/Profiling-.NET-MAUI-Apps

## MAUI

```
git clean -xdf
dotnet tool restore
dotnet cake --target=VS \
    --workloads=global

# --android --ios --windows --catalyst
dotnet cake --target=VS \
    --workloads=global \
        \--android \
        --ios \
        --catalyst
```

```
dotnet test \
    src/TestUtils/src/Microsoft.Maui.IntegrationTests \
        --logger "console;verbosity=diagnostic" \
        --filter "Name=Build\(%22maui%22,%22net7.0%22,%22Debug%22,False\)"

```



## Android

```
adb shell setprop debug.mono.log default,assembly,mono_log_level=debug,mono_log_mask=all
adb logcat -G 16M
adb logcat -c
# Start the application here and after it crashes do
adb logcat -d > log.txt
```

```

```

## Log

## TODO

*   https://github.com/dotnet/maui/issues?q=is%3Aissue+is%3Aopen+label%3A%22area%2Fessentials+%F0%9F%8D%9E%22+

*   https://github.com/dotnet/maui/issues?q=is%3Aissue+is%3Aopen+label%3A%22area%2Fessentials+%F0%9F%8D%9E%22+label%3A%22good+first+issue%22


*   Issue #3941

    *   Progress.ProgressTo() #3941

        *   https://github.com/dotnet/maui/issues/3941

        *   related

            *   https://stackoverflow.com/questions/54753199/xamarin-form-progressbar-method-progressto-doesnt-work-on-some-android-device

*   Issue #11476

    *   Add permission request for POST_NOTIFICATION to essentials for Android 13 and up #11476

        *   https://github.com/dotnet/maui/issues/11476

    *   links/references

        *   https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/appmodel/permissions

*   Issue #13721

    *   Requesting permissions to access nearby WiFi devices on Android 13+ #13721

        *   https://github.com/dotnet/maui/issues/13721

    *   links/references

        *   Requesting permissions to access nearby WiFi devices on Android 13+

*   Issue #12291

    *   Permission for Notifications #12291

        *   https://github.com/dotnet/maui/issues/12291

*   Issue #12264

    *   Requesting Bluetooth permissions on Android 12+ at runtime #12264

        *   https://github.com/dotnet/maui/issues/12264

    *   PR #
## WIP

## DONE

*   Issue #13446

    *   When using SMS permission on Android ReceiveSms is always requested while it shouldn't #13446

        *   https://github.com/dotnet/maui/issues/13446

    *   PR #14203

        *   Remove ReceiveSms added by default #14203

            *   https://github.com/dotnet/maui/pull/14203

*   Issue #13597

    *   SecureStorage throws InvalidProtocolBufferException on some devices #13597

        *   https://github.com/dotnet/maui/issues/13597

    *   PR #13938

        *   Bump version of AndroidX.Security.SecurityCrypto to 1.1.0-alpha05 #13938

            *   https://github.com/dotnet/maui/pull/13938

    *   PR #13599

        *   Catch InvalidProtocolBufferException creating EncryptedSharedPreferences #13599

            *   https://github.com/dotnet/maui/pull/13599


