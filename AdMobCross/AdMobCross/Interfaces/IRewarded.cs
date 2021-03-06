using System;
using AdMobCross.Models;

namespace AdMobCross.Interfaces
{
    public interface IRewarded : IDisposable
    {
        void Load(string adId);
        void Show();
        event Action AdLoaded;
        event Action AdFailed;
        event Action AdDismissedFullScreenContent;
        event Action AdFailedToShowFullScreenContent;
        event Action AdShowedFullScreenContent;
        event Action<RewardItem> AdEarnReward;
    }
}
