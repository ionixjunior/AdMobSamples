using System;
using System.Collections.Generic;
using AdMobCross.ViewModels;
using Xamarin.Forms;

namespace AdMobCross.Views
{
    public partial class NativeView : ContentPage
    {
        public NativeView()
        {
            InitializeComponent();
            BindingContext = new NativeViewModel();
        }
    }
}
