using System;
using AdMobCross.Controls;
using AdMobCross.Droid.Renderers;
using AdMobCross.Enums;
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
                var adSize = GetAdSize(e.NewElement.AdBannerSize);
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

        private AdSize GetAdSize(AdBannerSize adBannerSize)
        {
            return adBannerSize switch
            {
                AdBannerSize.Banner => AdSize.Banner,
                AdBannerSize.FullBanner => AdSize.FullBanner,
                AdBannerSize.LargeBanner => AdSize.LargeBanner,
                AdBannerSize.Leaderboard => AdSize.Leaderboard,
                AdBannerSize.MediumRectangle => AdSize.MediumRectangle,
                _ => AdSize.Invalid
            };
        }
    }
}
