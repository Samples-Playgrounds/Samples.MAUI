# Microsoft.Maui.Controls 9.x.x Issue with DispatchKeyEvent

```csharp
public class MainActivity : MauiAppCompatActivity
{
    public override bool DispatchKeyEvent(KeyEvent? e)
    {
        Console.WriteLine("This line isn't executed with Microsoft.Maui version 9.x.x, it is executed with version 8.0.100");

        return base.DispatchKeyEvent(e);
    }
}
```