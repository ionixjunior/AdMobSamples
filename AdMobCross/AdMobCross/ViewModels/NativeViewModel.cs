using System.Collections.Generic;
using System.Collections.ObjectModel;
using AdMobCross.Models;

namespace AdMobCross.ViewModels
{
    public class NativeViewModel
    {
        public ObservableCollection<NativeItem> Items { get; }

        public NativeViewModel()
        {
            Items = new ObservableCollection<NativeItem>(GetItems());
        }

        private List<NativeItem> GetItems()
        {
            var items = new List<NativeItem>();

            for (var index = 1; index <= 50; index++)
            {
                items.Add(new NativeItem($"Título {index}", $"Descrição {index}"));
            }

            return items;
        }
    }
}
