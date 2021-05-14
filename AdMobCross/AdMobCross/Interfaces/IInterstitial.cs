using System;

namespace AdMobCross.Interfaces
{
    public interface IInterstitial : IDisposable
    {
        void Load(string adId);
        void Show();
        event Action AdLoaded;
        event Action AdFailed;
        event Action AdDismissedFullScreenContent;
        event Action AdFailedToShowFullScreenContent;
        event Action AdShowedFullScreenContent;
    }
}
