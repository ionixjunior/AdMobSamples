using System;
using AdMobCross.Controls;
using AdMobCross.Enums;
using AdMobCross.iOS.Renderers;
using Google.MobileAds;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(AdView), typeof(AdViewRenderer))]
namespace AdMobCross.iOS.Renderers
{
    public class AdViewRenderer : ViewRenderer<AdView, UIView>
    {
        private AdView _adView;
        private BannerView _adBanner;

        protected override void OnElementChanged(ElementChangedEventArgs<AdView> e)
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
                var window = UIApplication.SharedApplication.KeyWindow;
                var vc = window.RootViewController;
                while (vc.PresentedViewController != null)
                {
                    vc = vc.PresentedViewController;
                }

                _adView = e.NewElement;
                _adView.IsVisible = true;

                var adSize = GetAdSize(_adView.AdBannerSize);
                _adBanner = new BannerView(adSize);
                _adBanner.ReceiveAdFailed += OnReceiveAdFailed;
                _adBanner.TranslatesAutoresizingMaskIntoConstraints = false;
                _adBanner.AdUnitId = _adView.AdId;
                _adBanner.RootViewController = vc;
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
