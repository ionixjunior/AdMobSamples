using System;
using AdMobCross.Controls;
using AdMobCross.Droid.Renderers;
using Android.Content;
using Android.Gms.Ads;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(AdMobCross.Controls.AdView), typeof(AdViewRenderer))]
namespace AdMobCross.Droid.Renderers
{
    public class AdViewRenderer : ViewRenderer<Controls.AdView, Android.Views.View>
    {
        public AdViewRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Controls.AdView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var adSize = AdSize.Banner;
                var adBanner = new Android.Gms.Ads.AdView(Context);
                adBanner.AdSize = adSize;
                adBanner.AdUnitId = e.NewElement.AdId;
                adBanner.LoadAd(new AdRequest.Builder().Build());
                // TODO considerar avaliar a falha do carregamento para alterar a constraint da altura

                e.NewElement.WidthRequest = adSize.Width;
                e.NewElement.HeightRequest = adSize.Height;

                SetNativeControl(adBanner);
            }
        }
    }
}
