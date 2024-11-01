using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanApp
{
    public static class Utilities
    {
        public static Element GetPage<T>(VisualElement ve)
        {
            if (ve?.Parent == null)
                return null;
            var e = ve.Parent;
            while (e != null && (e.GetType() != typeof(T)))
                e = e.Parent;
            return e;
        }
        public static async void PushPageNoBackAsync(NavigationPage np, Page p)
        {
            NavigationPage.SetHasBackButton(p, false);
            await np.PushAsync(p);
        }
    }
}
