using System;
using Xamarin.Forms;

namespace AdMobCross.Controls
{
    public class AdView : ContentView
    {
        public static readonly BindableProperty AdIdProperty = BindableProperty.Create(
            nameof(AdId),
            typeof(string),
            typeof(AdView),
            null,
            BindingMode.OneTime);

        public string AdId
        {
            get => (string)GetValue(AdIdProperty);
            set => SetValue(AdIdProperty, value);
        }
    }
}
