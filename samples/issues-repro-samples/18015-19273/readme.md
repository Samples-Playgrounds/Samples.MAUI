# Issue 18015 and 19273

readme.md

*   [regression/7.0.96] Picker is empty on mac catalyst #18015

    *   https://github.com/dotnet/maui/issues/18015

    *   MAUI Picker Control fails to show items in .NET 7 on Mac Catalyst Desktop #19273
    
        *   https://github.com/dotnet/maui/issues/19273

    *   https://developercommunity.visualstudio.com/t/MAUI-Picker-Control-fails-to-show-items/10516250

```csharp
#if !MACCATALYST
#else
#endif
```

Entry

#if !MACCATALYST
	public class MauiPicker : NoCaretField
#else
	public class MauiPicker : UIButton
#endif

    UIPickerView

    UITextField
    
        https://developer.apple.com/documentation/uikit/uitextfield

    UITextView

        https://developer.apple.com/documentation/uikit/uitextview
        

#

*   [regression/7.0.96] Picker is empty on mac catalyst #18015

    *   https://github.com/dotnet/maui/issues/18015

    *   MAUI Picker Control fails to show items in .NET 7 on Mac Catalyst Desktop #19273
    
        *   https://github.com/dotnet/maui/issues/19273

    *   https://developercommunity.visualstudio.com/t/MAUI-Picker-Control-fails-to-show-items/10516250

```csharp
#if !MACCATALYST
#else
#endif
```

Entry

#if !MACCATALYST
	public class MauiPicker : NoCaretField
#else
	public class MauiPicker : UIButton
#endif

    UIPickerView

    UITextField
    
        https://developer.apple.com/documentation/uikit/uitextfield

    UITextView

        https://developer.apple.com/documentation/uikit/uitextview
        

