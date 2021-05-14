using System;
using AdMobCross.Interfaces;
using AdMobCross.Models;

namespace AdMobCross.iOS.Implementations
{
    public class RewardediOS : IRewarded
    {
        public event Action AdLoaded;
        public event Action AdFailed;
        public event Action AdDismissedFullScreenContent;
        public event Action AdFailedToShowFullScreenContent;
        public event Action AdShowedFullScreenContent;
        public event Action<RewardItem> AdEarnReward;

        public void Load(string adId)
        {
            
        }

        public void Show()
        {
            
        }
    }
}
