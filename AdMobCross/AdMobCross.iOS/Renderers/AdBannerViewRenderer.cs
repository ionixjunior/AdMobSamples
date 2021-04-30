using System;
using AdMobCross.Controls;
using AdMobCross.Enums;
using AdMobCross.iOS.Renderers;
using Google.MobileAds;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(AdBannerView), typeof(AdBannerViewRenderer))]
namespace AdMobCross.iOS.Renderers
{
    public class AdBannerViewRenderer : ViewRenderer<AdBannerView, UIView>
    {
        private AdBannerView _adView;
        private BannerView _adBanner;

        protected override void OnElementChanged(ElementChangedEventArgs<AdBannerView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                if (_adBanner != null)
                {
                    _adBanner.ReceiveAdFailed -= OnReceiveAdFailed;
                }
            }

            if (e.NewElement != null)
            {
                _adView = e.NewElement;
                _adView.IsVisible = true;

                var adSize = GetAdSize(_adView.AdBannerSize);
                _adBanner = new BannerView(adSize);
                _adBanner.ReceiveAdFailed += OnReceiveAdFailed;
                _adBanner.TranslatesAutoresizingMaskIntoConstraints = false;
                _adBanner.AdUnitId = _adView.AdId;
                _adBanner.RootViewController = Xamarin.Essentials.Platform.GetCurrentUIViewController();
                _adBanner.LoadRequest(Request.GetDefaultRequest());

                _adView.WidthRequest = adSize.Size.Width;
                _adView.HeightRequest = adSize.Size.Height;

                SetNativeControl(_adBanner);
            }
        }

        private void OnReceiveAdFailed(object _, BannerViewErrorEventArgs __)
        {
            if (_adView != null)
                _adView.IsVisible = false;
        }

        private AdSize GetAdSize(AdBannerSize adBannerSize)
        {
            return adBannerSize switch
            {
                AdBannerSize.Banner => AdSizeCons.Banner,
                AdBannerSize.FullBanner => AdSizeCons.FullBanner,
                AdBannerSize.LargeBanner => AdSizeCons.LargeBanner,
                AdBannerSize.Leaderboard => AdSizeCons.Leaderboard,
                AdBannerSize.MediumRectangle => AdSizeCons.MediumRectangle,
                _ => AdSizeCons.Invalid
            };
        }
    }
}
