# Issue .NET9 MAUI appsettings System.UnauthorizedAccessException

System.UnauthorizedAccessException: Access to the path 'C:\source\net9_maui_appsetting_issue\MauiApp_NET_9\obj\Debug\net9.0-android\android\assets\x86_64\MauiApp_NET_9.dll' is denied.
   at System.IO.__Error.WinIOError(Int32 errorCode, String maybeFullPath)
   at System.IO.File.InternalDelete(String path, Boolean checkHost)
   at Microsoft.Android.Build.Tasks.Files.CopyIfChangedOnce(String source, String destination) in /Users/runner/work/1/s/xamarin-android/external/xamarin-android-tools/src/Microsoft.Android.Build.BaseTasks/Files.cs:line 197
   at Microsoft.Android.Build.Tasks.Files.CopyIfChanged(String source, String destination) in /Users/runner/work/1/s/xamarin-android/external/xamarin-android-tools/src/Microsoft.Android.Build.BaseTasks/Files.cs:line 176
   at Xamarin.Android.Tasks.MonoAndroidHelper.CopyAssemblyAndSymbols(String source, String destination) in /Users/runner/work/1/s/xamarin-android/src/Xamarin.Android.Build.Tasks/Utilities/MonoAndroidHelper.cs:line 394
   at Xamarin.Android.Tasks.LinkAssembliesNoShrink.CopyIfChanged(ITaskItem source, ITaskItem destination) in /Users/runner/work/1/s/xamarin-android/src/Xamarin.Android.Build.Tasks/Tasks/LinkAssembliesNoShrink.cs:line 161
   at Xamarin.Android.Tasks.LinkAssembliesNoShrink.RunTask() in /Users/runner/work/1/s/xamarin-android/src/Xamarin.Android.Build.Tasks/Tasks/LinkAssembliesNoShrink.cs:line 76
   at Microsoft.Android.Build.Tasks.AndroidTask.Execute() in /Users/runner/work/1/s/xamarin-android/external/xamarin-android-tools/src/Microsoft.Android.Build.BaseTasks/AndroidTask.cs:line 25

System.UnauthorizedAccessException: Access to the path 'GoogleGson.dll' is denied.
   at System.IO.Directory.DeleteHelper(String fullPath, String userPath, Boolean recursive, Boolean throwOnTopLevelDirectoryNotFound, WIN32_FIND_DATA& data)
   at System.IO.Directory.Delete(String fullPath, String userPath, Boolean recursive, Boolean checkHost)
   at Xamarin.Android.Tasks.RemoveDirFixed.RunTask() in /Users/runner/work/1/s/xamarin-android/src/Xamarin.Android.Build.Tasks/Tasks/RemoveDirFixed.cs:line 86
