using System;
using AdMobCross.Controls;
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

                var adSize = AdSizeCons.Banner;
                var adBanner = new BannerView(adSize);
                adBanner.TranslatesAutoresizingMaskIntoConstraints = false;
                adBanner.AdUnitId = "ca-app-pub-3940256099942544/2934735716";
                adBanner.RootViewController = vc;
                adBanner.LoadRequest(Request.GetDefaultRequest());
                // TODO considerar avaliar a falha do carregamento para alterar a constraint da altura

                e.NewElement.WidthRequest = adSize.Size.Width;
                e.NewElement.HeightRequest = adSize.Size.Height;

                SetNativeControl(adBanner);
            }
        }
    }
}
