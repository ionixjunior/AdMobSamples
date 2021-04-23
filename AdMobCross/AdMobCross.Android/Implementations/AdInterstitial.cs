using System;
using AdMobCross.Interfaces;
using Android.Gms.Ads;
using Android.Runtime;
using InterstitialAd = Android.Gms.Ads.Interstitial.InterstitialAd;

namespace AdMobCross.Droid.Implementations
{
    public class AdInterstitial : IAdInterstitial
    {
        private InterstitialAd? mInterstitialAd;
        public event Action AdLoaded;
        public event Action AdFailed;

        public AdInterstitial()
        {
        }

        public void Load()
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
                "ca-app-pub-3940256099942544/1033173712",
                adRequest,
                new CustomInterstitialAdLoadCallback(this)
            );
        }

        public void Show()
        {
            
        }

        private class CustomInterstitialAdLoadCallback : Android.Gms.Ads.AdLoadCallback
        {
            private AdInterstitial _adInterstitial;

            public CustomInterstitialAdLoadCallback(AdInterstitial adInterstitial)
            {
                _adInterstitial = adInterstitial;
            }

            public override void OnAdFailedToLoad(LoadAdError p0)
            {
                base.OnAdFailedToLoad(p0);
                System.Diagnostics.Debug.WriteLine("A propaganda falhou ao ser carregada");
                _adInterstitial.AdFailed?.Invoke();
            }

            public override void OnAdLoaded(Java.Lang.Object p0)
            {
                base.OnAdLoaded(p0);
                System.Diagnostics.Debug.WriteLine("A propaganda foi carregada");
                _adInterstitial.AdLoaded?.Invoke();
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
    }
}
