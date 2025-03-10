using Android.App;
using Android.Content;
using Android.Runtime;
using Android.OS;

namespace AppMAUI.net90;

public partial class 
                                        MainApplication
{
    public override
        void
                                        OnTerminate
                                        (
                                        )
    {
        base.OnTerminate();
    }
    
    public override
        void
                                        OnLowMemory
                                        (
                                        )
    {
        base.OnLowMemory();
    }
    
    public override
        void
    
                                        OnTrimMemory
                                        (
                                            [GeneratedEnum] TrimMemory level
                                        )
    {
        base.OnTrimMemory(level);
    }
    
}
