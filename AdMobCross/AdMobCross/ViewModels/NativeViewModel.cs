using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AdMobCross.Enums;
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
                items.Add(new Item($"Título {index}", $"Descrição {index}", ItemType.Item));
            }

            return items;
        }

        internal void OnCreated()
        {
            Task.Run(() => _native.Load(Constants.AdNativeId, 5));
            _native.AdLoaded += OnAdLoaded;
        }

        private void OnAdLoaded(NativeAd nativeAd)
        {
            Console.WriteLine($"A propaganda chegou na view!!! {nativeAd.Title}");
            Items.Add(new Item(nativeAd.Title, nativeAd.Description, ItemType.Ad));
        }

        internal void OnDestroyed()
        {
            _native.AdLoaded -= OnAdLoaded;
        }
    }
}
