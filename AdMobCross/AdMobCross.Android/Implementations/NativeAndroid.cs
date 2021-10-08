using System;
using AdMobCross.Interfaces;
using Android.Gms.Ads;
using Android.Gms.Ads.Formats;

namespace AdMobCross.Droid.Implementations
{
    public class NativeAndroid : INative
    {
        public void Load(string adId, int numberOfAds)
        {
            var adLoader = new AdLoader.Builder(Xamarin.Essentials.Platform.AppContext, adId);
            adLoader.ForUnifiedNativeAd(new UnifiedNativeAdLoadedListener());

            var adRequest = new AdRequest.Builder().Build();
            adLoader.Build().LoadAds(adRequest, numberOfAds);
        }

        private class UnifiedNativeAdLoadedListener : AdListener, UnifiedNativeAd.IOnUnifiedNativeAdLoadedListener
        {
            public void OnUnifiedNativeAdLoaded(UnifiedNativeAd ad)
            {
                Console.WriteLine($"Título: {ad.Headline} - Descrição: {ad.Body}");
            }
        }
    }
}
