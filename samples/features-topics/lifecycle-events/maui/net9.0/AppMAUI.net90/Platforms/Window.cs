namespace AppMAUI;

/// <summary>
/// Window class used for xplat Lifecycle
/// </summary>
/// <href="https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/app-lifecycle"/>
/// <href="https://www.syncfusion.com/blogs/post/configuring-life-cycle-events-in-net-maui-apps"/>
public partial class
                                        Window
                                        :
                                        Microsoft.Maui.Controls.Window,
                                        ITrace,
                                        ITraceNotFound
{
    public 
                                        Window
                                        (
                                        )
                                        :
                                        base()
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif

        return;
    }

    public 
                                        Window
                                        (
                                            Page page
                                        )
                                        :
                                        base(page)
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif

        return;
    }

    protected override 
        void
                                        OnCreated
                                        (
                                        )
    {
        // Register services
        
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif

        return;
    }

    protected override 
        void
                                        OnActivated
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif

        return;
    }

    protected override 
        void
                                        OnDeactivated
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif

        return;
    }

    protected override 
        void
                                        OnStopped
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return;
    }
    
    protected override 
        void
                                        OnResumed
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif

        return;
    }
    
    protected override 
        void
                                        OnDestroying
                                        (
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif
        
        return;
    }
    
    protected override 
        void
                                        OnBackgrounding
                                        (
                                            Microsoft.Maui.IPersistedState state
                                        )
    {
        #if HOLISTICWARE_TRACE
        TraceWriteLine();
        #endif
        #if HOLISTICWARE_NOTIMPLEMENTED
        throw new NotImplementedException();
        #endif

        return;
    }
}
