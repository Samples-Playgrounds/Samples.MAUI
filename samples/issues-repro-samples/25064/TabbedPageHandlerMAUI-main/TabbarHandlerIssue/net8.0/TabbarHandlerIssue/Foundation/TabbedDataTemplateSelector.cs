using System;
using TabbarHandlerIssue.Views;

namespace TabbarHandlerIssue.Foundation
{
    public class TabbedDataTemplateSelector : DataTemplateSelector
    {
        private readonly IDictionary<string, DataTemplate> TemplateMap =
        new Dictionary<string, DataTemplate>();

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is TabItem i)
            {
                TemplateMap.TryGetValue(i.Title, out var template);
                if (template == null)
                {
                    Page page = null;
                    if (i.Title == "Message")
                    {
                        page = new Page1();
                    }
                    else if (i.Title == "Leave")
                    {
                        page = new Page2();
                    }
                    else if (i.Title == "Appointment")
                    {
                        page = new Page3();
                    }
                    else if (i.Title == "Home")
                    {
                        page = new MorePage();
                    }

                    template = new DataTemplate(() => new NavigationPage(page)
                    {
                        BarTextColor = Colors.Black
                    });
                    TemplateMap[i.Title] = template;
                }

                return template;
            }

            return null;
        }
    }

}

