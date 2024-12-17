# 26310 The .NET 9 Maui app unable to read .json file #26310


*   https://github.com/dotnet/maui/issues/26310

    *   https://github.com/sharifxu/net9_maui_appsetting_issue

```csharp
var a = Assembly.GetExecutingAssembly();
using var stream = a.GetManifestResourceStream("Dome.Shared.appsettings.json");
configuration = new ConfigurationBuilder().AddJsonStream(stream).Build();
```

*   https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/storage/file-system-helpers

*   https://learn.microsoft.com/en-us/dotnet/android/messages/xa0101

```
Warning XA0101 : @(Content) build action is not supported
```

## `net8.0`

MacCatalyst:

```
2024-12-13 22:06:42.891 AppMAUI[77457:21177544] You've implemented -[<UIApplicationDelegate> application:performFetchWithCompletionHandler:], but you still need to add "fetch" to the list of your supported UIBackgroundModes in your Info.plist.
2024-12-13 22:06:42.914 AppMAUI[77457:21177544] Stream appsettings.1.json opened
2024-12-13 22:06:42.921 AppMAUI[77457:21177544] 1
2024-12-13 22:06:42.921 AppMAUI[77457:21177544] True
2024-12-13 22:06:42.921 AppMAUI[77457:21177544] Oh, that's nice...
2024-12-13 22:06:42.921 AppMAUI[77457:21177544] Stream appsettings.2.json opened
2024-12-13 22:06:42.923 AppMAUI[77457:21177544] 1
2024-12-13 22:06:42.923 AppMAUI[77457:21177544] True
2024-12-13 22:06:42.923 AppMAUI[77457:21177544] Oh, that's nice...
2024-12-13 22:06:43.756 AppMAUI[77457:21177544] +[IMKClient subclass]: chose IMKClient_Modern
2024-12-13 22:06:43.756 AppMAUI[77457:21177544] +[IMKInputSession subclass]: chose IMKInputSession_Modern
```

iOS:

```
  AppMAUI net8.0-ios                                                                                        Run (60,6s)
2024-12-13 22:11:36.263869+0100 AppMAUI[81693:21200453] Microsoft.iOS: Socket error while connecting to IDE on 1(62,3s)1:10000: Connection refused
2024-12-13 22:11:38.001216+0100 AppMAUI[81693:21200423] You've implemented -[<UIApplicationDelegate> application:performFetchWithCompletionHandler:], but you still need to add "fetch" to the list of your supported UIBackgroundModes in your Info.plist.                                                                                                     (62,3s)
2024-12-13 22:11:38.032718+0100 AppMAUI[81693:21200423] Stream appsettings.1.json opened
2024-12-13 22:11:38.042215+0100 AppMAUI[81693:21200423] 1
2024-12-13 22:11:38.042302+0100 AppMAUI[81693:21200423] True
2024-12-13 22:11:38.042356+0100 AppMAUI[81693:21200423] Oh, that's nice...
2024-12-13 22:11:38.042424+0100 AppMAUI[81693:21200423] Stream appsettings.2.json opened
2024-12-13 22:11:38.044196+0100 AppMAUI[81693:21200423] 1
2024-12-13 22:11:38.044264+0100 AppMAUI[81693:21200423] True
2024-12-13 22:11:38.044313+0100 AppMAUI[81693:21200423] Oh, that's nice...                                      (62,7s)
2024-12-13 22:11:38.413180+0100 AppMAUI[81693:21200423] WARNING: This app's CFBundleDevelopmentRegion is not a string value. This can lead to unexpected results at runtime. Please change CFBundleDevelopmentRegion in your Info.plist to a string value.                                                                                                      (62,8s)
2024-12-13 22:11:38.474368+0100 AppMAUI[81693:21200423] [TableView] Warning once only: UITableView was told to layout its visible cells and other contents without being in the view hierarchy (the table view or one of its superviews has not been added to a window). This may cause bugs by forcing views inside the table view to load and perform layout without accurate information (e.g. table view bounds, trait collection, layout margins, safe area insets, etc), and will also cause unnecessary performance overhead due to extra layout passes. Make a symbolic breakpoint at UITableViewAlertForLayoutOutsideViewHierarchy to catch this in the debugger and see what caused this to occur, so you can avoid this action altogether if possible, or defer it until the table view has been added to a window. Table view: <_UIMoreListTableView: 0x10760e600; frame = (0 0; 0 0); clipsToBounds = YES; gestureRecognizers = <NSArray: 0x600000d39830>; backgroundColor = <UIDynamicSystemColor: 0x60000176bc40; name = tableBackgroundColor>; layer = <CALayer: 0x6000007db980>; contentOffset:(62,9s); contentSize: {0, 0}; adjustedContentInset: {0, 0, 0, 0}; dataSource: <UIMoreListController: 0x105ce3400>>
2024-12-13 22:11:38.603333+0100 AppMAUI[81693:21200423] GSFont: "OpenSans-Regular" already exists.
2024-12-13 22:11:38.603496+0100 AppMAUI[81693:21200423] GSFontRegisterCGFont(<CGFont (0x600002c38c00): OpenSans-(81,4s)>) failed 305
```


```
error HE0004: Could not load the framework 'IDEDistribution' (path: /Applications/Xcode.app/Contents/SharedFrameworks/IDEDistribution.framework/Versions/A/IDEDistribution): 
dlopen(/Applications/Xcode.app/Contents/SharedFrameworks/IDEDistribution.framework/Versions/A/IDEDistribution, 0x0001): Library not loaded: @rpath/AppThinning.framework/Versions/A/AppThinning
  Referenced from: <92872593-91F4-31C4-86DF-8AB9691CAE03> /Applications/Xcode.app/Contents/SharedFrameworks/IDEDistribution.framework/Versions/A/IDEDistribution
  Reason: tried: '/Library/Frameworks/Xamarin.iOS.framework/Versions/16.4.0.23/lib/mlaunch/mlaunch.app/Contents/Frameworks/AppThinning.framework/Versions/A/AppThinning' (no such file), '/Applications/Xcode.app/Contents/SharedFrameworks/IDEDistribution.framework/Versions/A/Frameworks/AppThinning.framework/Versions/A/AppThinning' (no such file), '/Library/Frameworks/Xamarin.iOS.framework/Versions/16.4.0.23/lib/mlaunch/mlaunch.app/Contents/Frameworks/AppThinning.framework/Versions/A/AppThinning' (no such file), '/Applications/Xcode.app/Contents/SharedFrameworks/IDEDistribution.framework/Versions/A/Frameworks/AppThinning.framework/Versions/A/AppThinning' (no such file), '/Library/Frameworks/Xamarin.iOS.framework/Versions/16.4.0.23/lib/mlaunch/mlaunch.app/Contents/MonoBundle/AppThinning.framework/Versions/A/AppThinning' (no such file)
        
```

Android:

```
12-13 22:08:34.644 I/DOTNET  (22704): Stream appsettings.1.json opened
12-13 22:08:34.646 W/monodroid-assembly(22704): open_from_bundles: failed to load assembly System.Text.Json.dll
12-13 22:08:34.649 W/monodroid-assembly(22704): open_from_bundles: failed to load assembly System.Text.Encoding.Extensions.dll
12-13 22:08:34.662 W/monodroid-assembly(22704): open_from_bundles: failed to load assembly System.Runtime.Loader.dll
12-13 22:08:34.675 I/DOTNET  (22704): 1
12-13 22:08:34.675 I/DOTNET  (22704): True
12-13 22:08:34.675 I/DOTNET  (22704): Oh, that's nice...
12-13 22:08:34.675 I/DOTNET  (22704): Stream appsettings.2.json opened
12-13 22:08:34.675 I/DOTNET  (22704): 1
12-13 22:08:34.675 I/DOTNET  (22704): True
12-13 22:08:34.675 I/DOTNET  (22704): Oh, that's nice...
```

'AppMAUI.exe' (CoreCLR: clrhost): Loaded 'D:\Samples\MAUI\samples\issues-repro-samples\26310\net8.0\AppMAUI\bin\Debug\net8.0-windows10.0.19041.0\win10-x64\AppX\Microsoft.Extensions.Logging.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
'AppMAUI.exe' (CoreCLR: clrhost): Loaded 'D:\Samples\MAUI\samples\issues-repro-samples\26310\net8.0\AppMAUI\bin\Debug\net8.0-windows10.0.19041.0\win10-x64\AppX\Microsoft.Extensions.Options.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
Stream appsettings.1.json opened
'AppMAUI.exe' (CoreCLR: clrhost): Loaded 'C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.11\System.Text.Json.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
'AppMAUI.exe' (CoreCLR: clrhost): Loaded 'C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.11\System.Text.Encoding.Extensions.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
1
True
Oh, that's nice...
Stream appsettings.2.json opened
1
True
Oh, that's nice...


## `net9.0`

MacCatalyst:

```
2024-12-13 21:27:16.311 AppMAUI[48509:21048239] You've implemented -[<UIApplicationDelegate> application:performFetchWithCompletionHandler:], but you still need to add "fetch" to the list of your supported UIBackgroundModes in your Info.plist.
2024-12-13 21:27:16.337 AppMAUI[48509:21048239] Stream appsettings.1.json opened
2024-12-13 21:27:16.346 AppMAUI[48509:21048239] 1
2024-12-13 21:27:16.346 AppMAUI[48509:21048239] True
2024-12-13 21:27:16.346 AppMAUI[48509:21048239] Oh, that's nice...
2024-12-13 21:27:16.346 AppMAUI[48509:21048239] Stream appsettings.2.json opened
2024-12-13 21:27:16.347 AppMAUI[48509:21048239] 1
2024-12-13 21:27:16.347 AppMAUI[48509:21048239] True
2024-12-13 21:27:16.347 AppMAUI[48509:21048239] Oh, that's nice...
2024-12-13 21:27:16.758 AppMAUI[48509:21048239] WARNING: This app's CFBundleDevelopmentRegion is not a string value. This can lead to unexpected results at runtime. Please change CFBundleDevelopmentRegion in your Info.plist to a string value.
2024-12-13 21:27:17.306 AppMAUI[48509:21048239] +[IMKClient subclass]: chose IMKClient_Modern
2024-12-13 21:27:17.306 AppMAUI[48509:21048239] +[IMKInputSession subclass]: chose IMKInputSession_Modern
```

Android:

```
12-13 21:53:59.508 I/DOTNET  (20029): Stream appsettings.1.json opened
12-13 21:53:59.511 W/monodroid-assembly(20029): open_from_bundles: failed to load bundled assembly System.Text.Json.dll
12-13 21:53:59.511 W/monodroid-assembly(20029): open_from_bundles: the assembly might have been uploaded to the device with FastDev instead
12-13 21:53:59.512 W/monodroid-assembly(20029): open_from_bundles: failed to load bundled assembly System.IO.Pipelines.dll
12-13 21:53:59.512 W/monodroid-assembly(20029): open_from_bundles: the assembly might have been uploaded to the device with FastDev instead
12-13 21:53:59.516 W/monodroid-assembly(20029): open_from_bundles: failed to load bundled assembly System.Text.Encoding.Extensions.dll
12-13 21:53:59.516 W/monodroid-assembly(20029): open_from_bundles: the assembly might have been uploaded to the device with FastDev instead
12-13 21:53:59.521 W/monodroid-assembly(20029): open_from_bundles: failed to load bundled assembly System.Text.RegularExpressions.dll
12-13 21:53:59.521 W/monodroid-assembly(20029): open_from_bundles: the assembly might have been uploaded to the device with FastDev instead
12-13 21:53:59.533 I/DOTNET  (20029): 1
12-13 21:53:59.534 I/DOTNET  (20029): True
12-13 21:53:59.534 I/DOTNET  (20029): Oh, that's nice...
12-13 21:53:59.534 I/DOTNET  (20029): Stream appsettings.2.json opened
12-13 21:53:59.535 I/DOTNET  (20029): 1
12-13 21:53:59.536 I/DOTNET  (20029): True
12-13 21:53:59.536 I/DOTNET  (20029): Oh, that's nice...
```

iOS:

```
  AppMAUI net9.0-ios                                                                                        Run (54,9s)
2024-12-13 22:13:29.587511+0100 AppMAUI[83367:21211088] Microsoft.iOS: Socket error while connecting to IDE on 1(56,2s)1:10000: Connection refused
2024-12-13 22:13:30.879934+0100 AppMAUI[83367:21211022] You've implemented -[<UIApplicationDelegate> application:performFetchWithCompletionHandler:], but you still need to add "fetch" to the list of your supported UIBackgroundModes in your Info.plist.                                                                                                     (56,2s)
2024-12-13 22:13:30.912035+0100 AppMAUI[83367:21211022] Stream appsettings.1.json opened
2024-12-13 22:13:30.923544+0100 AppMAUI[83367:21211022] 1
2024-12-13 22:13:30.923648+0100 AppMAUI[83367:21211022] True
2024-12-13 22:13:30.923721+0100 AppMAUI[83367:21211022] Oh, that's nice...
2024-12-13 22:13:30.923792+0100 AppMAUI[83367:21211022] Stream appsettings.2.json opened
2024-12-13 22:13:30.926083+0100 AppMAUI[83367:21211022] 1
2024-12-13 22:13:30.926139+0100 AppMAUI[83367:21211022] True
2024-12-13 22:13:30.926202+0100 AppMAUI[83367:21211022] Oh, that's nice...                                      (56,6s)
2024-12-13 22:13:31.307476+0100 AppMAUI[83367:21211022] GSFont: invalid font file - "file:///Users/moljac/Library/Developer/CoreSimulator/Devices/DCC8438B-8937-4817-9D71-F7C18BFC9733/data/Containers/Bundle/Application/897E1490-BECC-43A3-8B83-A5A442CAE032/AppMAUI.app/FluentUI.cs"                                                                         (56,7s)
2024-12-13 22:13:31.366843+0100 AppMAUI[83367:21211022] WARNING: This app's CFBundleDevelopmentRegion is not a string value. This can lead to unexpected results at runtime. Please change CFBundleDevelopmentRegion in your Info.plist to a string value.                                                                                                      (56,8s)
2024-12-13 22:13:31.515936+0100 AppMAUI[83367:21211022] GSFont: "OpenSans-Regular" already exists.
2024-12-13 22:13:31.516089+0100 AppMAUI[83367:21211022] GSFontRegisterCGFont(<CGFont (0x600002c38f80): OpenSans-(56,9s)>) failed 305
2024-12-13 22:13:31.618088+0100 AppMAUI[83367:21211162] [General] Failed to send CA Event for app launch measure(57,0s)or ca_event_type: 0 event_name: com.apple.app_launch_measurement.FirstFramePresentationMetric
2024-12-13 22:13:31.692886+0100 AppMAUI[83367:21211161] [General] Failed to send CA Event for app launch measure(65,7s)or ca_event_type: 1 event_name: com.apple.app_launch_measurement.ExtendedLaunchMetrics
```

'AppMAUI.exe' (CoreCLR: clrhost): Loaded 'C:\Program Files\dotnet\shared\Microsoft.NETCore.App\9.0.0\System.Text.Encoding.Extensions.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
1
True
Oh, that's nice...
Stream appsettings.2.json opened
1
True
Oh, that's nice...
