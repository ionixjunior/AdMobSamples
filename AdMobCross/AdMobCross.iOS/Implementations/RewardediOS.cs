using System;
using AdMobCross.Interfaces;
using AdMobCross.Models;
using Foundation;
using Google.MobileAds;

namespace AdMobCross.iOS.Implementations
{
    public class RewardediOS : NSObject, IRewarded
    {
        public event Action AdLoaded;
        public event Action AdFailed;
        public event Action AdDismissedFullScreenContent;
        public event Action AdFailedToShowFullScreenContent;
        public event Action AdShowedFullScreenContent;
        public event Action<RewardItem> AdEarnReward;

        public void Load(string adId)
        {
            var request = Request.GetDefaultRequest();

            RewardBasedVideoAd.SharedInstance.LoadRequest(request, adId);
            RewardBasedVideoAd.SharedInstance.AdReceived += OnAdReceived;
            RewardBasedVideoAd.SharedInstance.FailedToLoad += OnFailedToLoad;
        }

        private void OnAdReceived(object sender, EventArgs e)
        {
            AdLoaded?.Invoke();
        }

        private void OnFailedToLoad(object sender, RewardBasedVideoAdErrorEventArgs e)
        {
            AdFailed?.Invoke();
        }

        private void OnClosed(object sender, EventArgs e)
        {
            AdDismissedFullScreenContent?.Invoke();
        }

        private void OnOpened(object sender, EventArgs e)
        {
            AdShowedFullScreenContent?.Invoke();
        }

        private void OnUserRewarded(object sender, RewardBasedVideoAdRewardEventArgs e)
        {
            int.TryParse(e.Reward.Amount.ToString(), out int amount);

            if (amount is 0)
                return;

            AdEarnReward?.Invoke(new RewardItem(amount, e.Reward.Type));
        }

        public void Show()
        {
            if (RewardBasedVideoAd.SharedInstance.IsReady)
            {
                RewardBasedVideoAd.SharedInstance.Closed += OnClosed;
                RewardBasedVideoAd.SharedInstance.Opened += OnOpened;
                RewardBasedVideoAd.SharedInstance.UserRewarded += OnUserRewarded;
                RewardBasedVideoAd.SharedInstance.Present(Xamarin.Essentials.Platform.GetCurrentUIViewController());
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            AdLoaded = null;
            AdFailed = null;
            AdDismissedFullScreenContent = null;
            AdFailedToShowFullScreenContent = null;
            AdShowedFullScreenContent = null;
            AdEarnReward = null;

            RewardBasedVideoAd.SharedInstance.AdReceived -= OnAdReceived;
            RewardBasedVideoAd.SharedInstance.FailedToLoad -= OnFailedToLoad;
            RewardBasedVideoAd.SharedInstance.Closed -= OnClosed;
            RewardBasedVideoAd.SharedInstance.Opened -= OnOpened;
            RewardBasedVideoAd.SharedInstance.UserRewarded -= OnUserRewarded;
        }
    }
}
