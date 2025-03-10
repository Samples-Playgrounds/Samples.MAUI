using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSample
{
    internal sealed class MainPageViewModel
    {
        public List<Item> Items { get; }

        internal MainPageViewModel()
        {
            Items = new List<Item>();
            for (int i = 1; i <= 500; i++)
            {
                Items.Add(new Item($"Item {i}", i * 10, "dotnet_bot.png"));
            }
        }
    }

    internal record Item(string Name, decimal Price, string Image);

}
