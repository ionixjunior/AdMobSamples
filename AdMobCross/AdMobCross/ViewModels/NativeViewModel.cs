using System.Collections.Generic;
using System.Collections.ObjectModel;
using AdMobCross.Interfaces;
using AdMobCross.Models;

namespace AdMobCross.ViewModels
{
    public class NativeViewModel
    {
        private readonly INative _native;
        public ObservableCollection<NativeItem> Items { get; }

        public NativeViewModel(INative native)
        {
            _native = native;
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
