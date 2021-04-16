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
        protected override void OnElementChanged(ElementChangedEventArgs<AdView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var window = UIApplication.SharedApplication.KeyWindow;
                var vc = window.RootViewController;
                while (vc.PresentedViewController != null)
                {
                    vc = vc.PresentedViewController;
                }

                var adSize = GetAdSize(e.NewElement.AdBannerSize);
                var adBanner = new BannerView(adSize);
                adBanner.TranslatesAutoresizingMaskIntoConstraints = false;
                adBanner.AdUnitId = e.NewElement.AdId;
                adBanner.RootViewController = vc;
                adBanner.LoadRequest(Request.GetDefaultRequest());
                // TODO considerar avaliar a falha do carregamento para alterar a constraint da altura

                e.NewElement.WidthRequest = adSize.Size.Width;
                e.NewElement.HeightRequest = adSize.Size.Height;

                SetNativeControl(adBanner);
            }
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
