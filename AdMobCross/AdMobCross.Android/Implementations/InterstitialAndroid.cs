using System;
using AdMobCross.Interfaces;
using Android.Gms.Ads;
using Android.Runtime;
using InterstitialAd = Android.Gms.Ads.Interstitial.InterstitialAd;

namespace AdMobCross.Droid.Implementations
{
    public class InterstitialAndroid : IInterstitial
    {
        private InterstitialAd? _interstitialAd;
        public event Action AdLoaded;
        public event Action AdFailed;
        public event Action AdDismissedFullScreenContent;
        public event Action AdFailedToShowFullScreenContent;
        public event Action AdShowedFullScreenContent;

        public void Load(string adId)
        {
            var adRequest = new AdRequest.Builder().Build();

            // "Temporariamente" removido devido a este issue https://github.com/xamarin/GooglePlayServicesComponents/issues/425
            //InterstitialAd.Load(
            //    Xamarin.Essentials.Platform.AppContext,
            //    "ca-app-pub-3940256099942544/1033173712",
            //    adRequest,
            //    new CustomInterstitialAdLoadCallback()
            //);

            CustomInterstitialAdLoadCallback.LoadInterstitial(
                Xamarin.Essentials.Platform.AppContext,
                adId,
                adRequest,
                new CustomInterstitialAdLoadCallback(this)
            );
        }

        public void Show()
        {
            _interstitialAd?.Show(Xamarin.Essentials.Platform.CurrentActivity);
        }

        private class CustomInterstitialAdLoadCallback : AdLoadCallback
        {
            private InterstitialAndroid _interstitialAndroid;

            public CustomInterstitialAdLoadCallback(InterstitialAndroid interstitialAndroid)
            {
                _interstitialAndroid = interstitialAndroid;
            }

            public override void OnAdFailedToLoad(LoadAdError p0)
            {
                base.OnAdFailedToLoad(p0);
                System.Diagnostics.Debug.WriteLine("A propaganda falhou ao ser carregada");

                _interstitialAndroid.AdFailed?.Invoke();
            }

            public override void OnAdLoaded(Java.Lang.Object p0)
            {
                base.OnAdLoaded(p0);
                System.Diagnostics.Debug.WriteLine("A propaganda foi carregada");

                _interstitialAndroid._interstitialAd = (InterstitialAd)p0;
                _interstitialAndroid.AdLoaded?.Invoke();

                _interstitialAndroid._interstitialAd.FullScreenContentCallback = new CustomFullScreenContentCallback(_interstitialAndroid);
            }

            public static void LoadInterstitial(Android.Content.Context context, string Adunit, Android.Gms.Ads.AdRequest adRequest, Android.Gms.Ads.AdLoadCallback Callback)
            {
                IntPtr AdRequestClass = JNIEnv.GetObjectClass(adRequest.Handle);
                IntPtr zzdsmethodID = JNIEnv.GetMethodID(AdRequestClass, "zzds", "()Lcom/google/android/gms/internal/ads/zzzk;");
                Java.Lang.Object zzzk = GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(adRequest.Handle, zzdsmethodID), JniHandleOwnership.TransferLocalRef);

                IntPtr zzakjtype = JNIEnv.FindClass("com/google/android/gms/internal/ads/zzakj");
                IntPtr zzakjConstructor = JNIEnv.GetMethodID(zzakjtype, "<init>", "(Landroid/content/Context;Ljava/lang/String;)V");
                IntPtr zzakjInstance = JNIEnv.NewObject(zzakjtype, zzakjConstructor, new JValue[] { new JValue(context), new JValue(new Java.Lang.String(Adunit)) });

                IntPtr LoadMethodId = JNIEnv.GetMethodID(zzakjtype, "zza", "(Lcom/google/android/gms/internal/ads/zzzk;Lcom/google/android/gms/ads/AdLoadCallback;)V");
                JNIEnv.CallVoidMethod(zzakjInstance, LoadMethodId, new JValue[] { new JValue(zzzk), new JValue(Callback) });
            }
        }

        private class CustomFullScreenContentCallback : FullScreenContentCallback
        {
            private InterstitialAndroid _interstitialAndroid;

            public CustomFullScreenContentCallback(InterstitialAndroid interstitialAndroid)
            {
                _interstitialAndroid = interstitialAndroid;
            }

            public override void OnAdDismissedFullScreenContent()
            {
                base.OnAdDismissedFullScreenContent();
                _interstitialAndroid.AdDismissedFullScreenContent?.Invoke();
            }

            public override void OnAdFailedToShowFullScreenContent(AdError p0)
            {
                base.OnAdFailedToShowFullScreenContent(p0);
                _interstitialAndroid.AdFailedToShowFullScreenContent?.Invoke();
            }

            public override void OnAdShowedFullScreenContent()
            {
                base.OnAdShowedFullScreenContent();
                _interstitialAndroid.AdShowedFullScreenContent?.Invoke();
            }
        }
    }
}
