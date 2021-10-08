using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdMobCross.Interfaces;
using AdMobCross.ViewModels;
using Xamarin.Forms;

namespace AdMobCross.Views
{
    public partial class NativeView : ContentPage, ILifecycleLite
    {
        private readonly INative _native;

        public NativeView()
        {
            InitializeComponent();
            _native = DependencyService.Resolve<INative>();
            BindingContext = new NativeViewModel(_native);
        }

        public void OnCreated()
        {
            Task.Run(() => _native.Load(Constants.AdNativeId, 5));
            _native.AdLoaded += OnAdLoaded;
        }

        private void OnAdLoaded(Models.NativeAd nativeAd)
        {
            Console.WriteLine($"A propaganda chegou na view!!! {nativeAd.Title}");
        }

        public void OnDestroyed()
        {
            _native.AdLoaded -= OnAdLoaded;
        }
    }
}
