# Post Notifications

Repro sample + Notes

[Sample.Issue_12291.PostNotifications.zip](https://github.com/dotnet/maui/files/11193801/Sample.Issue_12291.PostNotifications.zip)



*   https://github.com/dotnet/maui/issues/12291

    *   related:

        *   https://github.com/dotnet/maui/issues/11476

PR https://github.com/dotnet/maui/pull/14456

To enable notifications and to build added:

```xml
	<uses-permission android:name="android.permission.POST_NOTIFICATIONS" />
	<uses-sdk
			android:minSdkVersion="21"
			android:targetSdkVersion="33"
            />
```

Works on API 31 and API32

API 33 log message (no error/exception):

```
[com.companyname.sample.issue_12291.postnotifications] Show: Notifications are disabled
```

TODO:

*   Refine sample

## Links

*   https://github.com/androidmads/MauiTutorial7/blob/master/MainPage.xaml.cs

*   https://www.c-sharpcorner.com/article/net-maui-local-notification/

