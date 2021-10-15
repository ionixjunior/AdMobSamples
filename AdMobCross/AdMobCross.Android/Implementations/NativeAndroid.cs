using System;
using System.Collections.Generic;
using AdMobCross.Interfaces;
using Android.Gms.Ads;
using Android.Gms.Ads.Formats;

namespace AdMobCross.Droid.Implementations
{
    public class NativeAndroid : INative
    {
        private List<UnifiedNativeAd> _ads = new List<UnifiedNativeAd>();

        public event Action<Models.NativeAd> AdLoaded;

        public void Load(string adId, int numberOfAds)
        {
            var adLoader = new AdLoader.Builder(Xamarin.Essentials.Platform.AppContext, adId);
            adLoader.ForUnifiedNativeAd(new UnifiedNativeAdLoadedListener(this));

            var adRequest = new AdRequest.Builder().Build();
            adLoader.Build().LoadAds(adRequest, numberOfAds);
        }

        public void Dispose()
        {
            _ads.ForEach(x => x.Dispose());
        }

        private class UnifiedNativeAdLoadedListener : AdListener, UnifiedNativeAd.IOnUnifiedNativeAdLoadedListener
        {
            private readonly NativeAndroid _nativeAndroid;

            public UnifiedNativeAdLoadedListener(NativeAndroid nativeAndroid)
            {
                _nativeAndroid = nativeAndroid;
            }

            public void OnUnifiedNativeAdLoaded(UnifiedNativeAd ad)
            {
                _nativeAndroid._ads.Add(ad);
                _nativeAndroid.AdLoaded?.Invoke(new Models.NativeAd(ad.Headline, ad.Body, ad.Icon.Uri.ToString()));
            }
        }
    }
}
