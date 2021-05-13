using System;
using AdMobCross.Interfaces;
using AdMobCross.Models;
using Android.Gms.Ads;
using Android.Gms.Ads.Reward;

namespace AdMobCross.Droid.Implementations
{
    public class RewardedAndroid : IRewarded
    {
        private IRewardedVideoAd? _rewardedAd;
        public event Action AdLoaded;
        public event Action AdFailed;
        public event Action AdDismissedFullScreenContent;
        public event Action AdFailedToShowFullScreenContent;
        public event Action AdShowedFullScreenContent;
        public event Action<RewardItem> AdEarnReward;

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

            _rewardedAd = MobileAds.GetRewardedVideoAdInstance(Xamarin.Essentials.Platform.AppContext);
            _rewardedAd.RewardedVideoAdListener = new CustomRewardedAdListener(this);
            _rewardedAd.LoadAd("ca-app-pub-3940256099942544/5224354917", adRequest);
        }

        public void Show()
        {
            _rewardedAd?.Show();
        }

        private class CustomRewardedAdListener : Java.Lang.Object, IRewardedVideoAdListener
        {
            private readonly RewardedAndroid _rewardedAndroid;

            public CustomRewardedAdListener(RewardedAndroid rewardedAndroid)
            {
                _rewardedAndroid = rewardedAndroid;
            }

            public void OnRewarded(Android.Gms.Ads.Reward.IRewardItem reward)
            {
                _rewardedAndroid.AdEarnReward?.Invoke(new RewardItem(reward.Amount, reward.Type));
            }

            public void OnRewardedVideoAdClosed()
            {
                _rewardedAndroid.AdDismissedFullScreenContent?.Invoke();
            }

            public void OnRewardedVideoAdFailedToLoad(int errorCode)
            {
                _rewardedAndroid.AdFailed?.Invoke();
            }

            public void OnRewardedVideoAdLeftApplication()
            {
            }

            public void OnRewardedVideoAdLoaded()
            {
                _rewardedAndroid.AdLoaded?.Invoke();
            }

            public void OnRewardedVideoAdOpened()
            {
                _rewardedAndroid.AdShowedFullScreenContent?.Invoke();
            }

            public void OnRewardedVideoCompleted()
            {
            }

            public void OnRewardedVideoStarted()
            {
            }
        }
    }
}
