using System.Collections.Generic;
using System.Collections.ObjectModel;
using AdMobCross.Interfaces;
using AdMobCross.Models;

namespace AdMobCross.ViewModels
{
    public class NativeViewModel
    {
        private readonly INative _native;
        public ObservableCollection<Item> Items { get; }

        public NativeViewModel(INative native)
        {
            _native = native;
            Items = new ObservableCollection<Item>(GetItems());
        }

        private List<Item> GetItems()
        {
            var items = new List<Item>();

            for (var index = 1; index <= 50; index++)
            {
                items.Add(new Item($"Título {index}", $"Descrição {index}"));
            }

            return items;
        }
    }
}
