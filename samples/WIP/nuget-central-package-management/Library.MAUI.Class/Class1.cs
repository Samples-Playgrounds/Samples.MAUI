namespace Library.MAUI.Class
{
    public partial class Class1
    {
        public partial void DoWork();

#if ANDROID
        // Code block for Android
#elif IOS
        // Code block for iOS
#elif MACCATALYST
        // Code block for Mac Catalyst
#elif TIZEN
        // Code block for Tizen
#elif WINDOWS
        // Code block for Windows
#else
        // Code block for unsupported Platforms
        public partial void DoWork()
        {
            // Could even be like the below exception
            //throw new PlatformNotSupportedException();
        }
#endif
    }
}
