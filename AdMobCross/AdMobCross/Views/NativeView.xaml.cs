using System;
using System.Collections.Generic;
using AdMobCross.Interfaces;
using AdMobCross.ViewModels;
using Xamarin.Forms;

namespace AdMobCross.Views
{
    public partial class NativeView : ContentPage
    {
        public NativeView()
        {
            InitializeComponent();
            var native = DependencyService.Resolve<INative>();
            BindingContext = new NativeViewModel(native);
        }
    }
}
