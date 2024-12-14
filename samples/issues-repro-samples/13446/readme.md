# Repro Sample - Issue 13446 - Android ReceiveSms is always requested

*   Issue #13446

    *   When using SMS permission on Android ReceiveSms is always requested while it shouldn't #13446

        *   https://github.com/dotnet/maui/issues/13446

    *   PR #14203

        *   Remove ReceiveSms added by default #14203

            *   https://github.com/dotnet/maui/pull/14203

## Samples / Source

*   https://github.com/dotnet/maui/blob/main/src/Essentials/src/Permissions/Permissions.android.cs#L61-L62

*   https://github.com/dotnet/maui/blob/main/src/Essentials/src/Permissions/Permissions.android.cs#L448-L451