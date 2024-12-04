using Microsoft.JSInterop;

namespace TodoApp
{
    public static class MyJsInterop
    {

        public static bool IsReady = false;
        public static IJSRuntime jsRuntime = null;

        public static ValueTask<string> setTextToCurrentPos(string elementID, string value)
        {
            return jsRuntime.InvokeAsync<string>(
               "MyJSFunctions.setTextToCurrentPos", elementID, value);
        }

    }
}