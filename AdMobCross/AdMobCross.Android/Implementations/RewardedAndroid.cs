using System;
using AdMobCross.Interfaces;
using Android.Gms.Ads;
using Android.Gms.Ads.Rewarded;
using Android.Runtime;
using Java.Interop;
using RewardedAd = Android.Gms.Ads.Rewarded.RewardedAd;

namespace AdMobCross.Droid.Implementations
{
    public class RewardedAndroid : IRewarded
    {
        private RewardedAd? _rewardedAd;
        public event Action AdLoaded;
        public event Action AdFailed;
        public event Action AdDismissedFullScreenContent;
        public event Action AdFailedToShowFullScreenContent;
        public event Action AdShowedFullScreenContent;
        public event Action AdEarnReward;

        public void Load(string adId)
        {
            var adRequest = new AdRequest.Builder().Build();

            // "Temporariamente" removido devido a este issue https://github.com/xamarin/GooglePlayServicesComponents/issues/425
            //RewardedAd.Load(
            //    Xamarin.Essentials.Platform.AppContext,
            //    "ca-app-pub-3940256099942544/5224354917",
            //    adRequest,
            //    new CustomRewardedAdLoadCallback(this)
            //);

            CustomRewardedAdLoadCallback.LoadRewarded(
                Xamarin.Essentials.Platform.AppContext,
                "ca-app-pub-3940256099942544/5224354917",
                adRequest,
                new CustomRewardedAdLoadCallback(this)
            );
        }

        public void Show()
        {
            _rewardedAd?.Show(Xamarin.Essentials.Platform.CurrentActivity, new UserEarnedRewardListener());
        }

        private class CustomRewardedAdLoadCallback : AdLoadCallback
        {
            private readonly RewardedAndroid _rewardedAndroid;

            public CustomRewardedAdLoadCallback(RewardedAndroid rewardedAndroid)
            {
                _rewardedAndroid = rewardedAndroid;
            }

            public override void OnAdFailedToLoad(LoadAdError p0)
            {
                base.OnAdFailedToLoad(p0);
                System.Diagnostics.Debug.WriteLine("A propaganda falhou ao ser carregada");

                _rewardedAndroid.AdFailed?.Invoke();
            }

            public override void OnAdLoaded(Java.Lang.Object p0)
            {
                base.OnAdLoaded(p0);
                System.Diagnostics.Debug.WriteLine("A propaganda foi carregada");

                _rewardedAndroid._rewardedAd = (RewardedAd)p0;
                _rewardedAndroid.AdLoaded?.Invoke();

                _rewardedAndroid._rewardedAd.FullScreenContentCallback = new CustomFullScreenContentCallback(_rewardedAndroid);
            }

            private static readonly JniPeerMembers _members = (JniPeerMembers)(object)new XAPeerMembers("com/google/android/gms/ads/rewarded/RewardedAdLoadCallback", typeof(RewardedAdLoadCallback));
            protected override Type ThresholdType => _members.ManagedPeerType;
            public override JniPeerMembers JniPeerMembers => _members;
            
            public static void LoadRewarded(Android.Content.Context context, string Adunit, Android.Gms.Ads.AdRequest adRequest, Android.Gms.Ads.AdLoadCallback Callback)
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
            private RewardedAndroid _rewardedAndroid;

            public CustomFullScreenContentCallback(RewardedAndroid rewardedAndroid)
            {
                _rewardedAndroid = rewardedAndroid;
            }

            public override void OnAdDismissedFullScreenContent()
            {
                base.OnAdDismissedFullScreenContent();
                _rewardedAndroid.AdDismissedFullScreenContent?.Invoke();
            }

            public override void OnAdFailedToShowFullScreenContent(AdError p0)
            {
                base.OnAdFailedToShowFullScreenContent(p0);
                _rewardedAndroid.AdFailedToShowFullScreenContent?.Invoke();
            }

            public override void OnAdShowedFullScreenContent()
            {
                base.OnAdShowedFullScreenContent();
                _rewardedAndroid.AdShowedFullScreenContent?.Invoke();
            }
        }

        private class UserEarnedRewardListener : Java.Lang.Object, IOnUserEarnedRewardListener
        {
            public void OnUserEarnedReward(IRewardItem rewardItem)
            {
                System.Diagnostics.Debug.WriteLine($"Você ganhou! Amount: {rewardItem.Amount} - Type: {rewardItem.Type}");
            }
        }
    }
}
