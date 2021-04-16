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
                e.NewElement.IsVisible = true;
                var adSize = GetAdSize(e.NewElement.AdBannerSize);
                var adBanner = new Android.Gms.Ads.AdView(Context);
                adBanner.AdListener = new CustomAdListener(e.NewElement);
                adBanner.AdSize = adSize;
                adBanner.AdUnitId = e.NewElement.AdId;
                adBanner.LoadAd(new AdRequest.Builder().Build());

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

    public class CustomAdListener : AdListener
    {
        private readonly View _adView;

        public CustomAdListener(View adView)
        {
            _adView = adView;
        }

        public override void OnAdFailedToLoad(LoadAdError p0)
        {
            base.OnAdFailedToLoad(p0);
            _adView.IsVisible = false;
        }
    }
}
