using System;
using System.Collections.Generic;
using AdMobCross.Interfaces;
using AdMobCross.Models;

namespace AdMobCross.iOS.Implementations
{
    public class NativeiOS : Google.MobileAds.UnifiedNativeAdLoaderDelegate, INative, Google.MobileAds.IAdLoaderDelegate
    {
        private List<Google.MobileAds.UnifiedNativeAd> _ads = new List<Google.MobileAds.UnifiedNativeAd>();

        public event Action<NativeAd> AdLoaded;

        public void Load(string adId, int numberOfAds)
        {
            var multipleAdsOptions = new Google.MobileAds.MultipleAdsAdLoaderOptions();
            multipleAdsOptions.NumberOfAds = numberOfAds;

            var adLoader = new Google.MobileAds.AdLoader(
                adId,
                Xamarin.Essentials.Platform.GetCurrentUIViewController(),
                new Google.MobileAds.AdLoaderAdType[] { Google.MobileAds.AdLoaderAdType.UnifiedNative },
                new Google.MobileAds.AdLoaderOptions[] { multipleAdsOptions }
            );

            var request = Google.MobileAds.Request.GetDefaultRequest();
            adLoader.Delegate = this;
            adLoader.LoadRequest(request);
        }

        public void Dispose()
        {
            _ads.ForEach(x => x.Dispose());
        }

        public override void DidReceiveUnifiedNativeAd(Google.MobileAds.AdLoader adLoader, Google.MobileAds.UnifiedNativeAd ad)
        {
            System.Diagnostics.Debug.WriteLine("A propaganda foi carregada");
            _ads.Add(ad);
            AdLoaded?.Invoke(new Models.NativeAd(ad.Headline, ad.Body, ad.Icon.ImageUrl.ToString()));
        }

        public override void DidFailToReceiveAd(Google.MobileAds.AdLoader adLoader, Google.MobileAds.RequestError error)
        {
            System.Diagnostics.Debug.WriteLine("Falha ao carregar a propaganda");
        }
    }
}
