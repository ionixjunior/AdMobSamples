using System;
using AdMobCross.Enums;
using Xamarin.Forms;

namespace AdMobCross.Controls
{
    public class AdBannerView : ContentView
    {
        public static readonly BindableProperty AdIdProperty = BindableProperty.Create(
            nameof(AdId),
            typeof(string),
            typeof(AdBannerView),
            null,
            BindingMode.OneTime);

        public string AdId
        {
            get => (string)GetValue(AdIdProperty);
            set => SetValue(AdIdProperty, value);
        }

        public static readonly BindableProperty AdBannerSizeProperty = BindableProperty.Create(
            nameof(AdBannerSize),
            typeof(AdBannerSize),
            typeof(AdBannerView),
            Enums.AdBannerSize.Banner,
            BindingMode.OneTime);

        public AdBannerSize AdBannerSize
        {
            get => (AdBannerSize)GetValue(AdBannerSizeProperty);
            set => SetValue(AdBannerSizeProperty, value);
        }
    }
}
