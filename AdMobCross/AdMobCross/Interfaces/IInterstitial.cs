using System;

namespace AdMobCross.Interfaces
{
    public interface IInterstitial
    {
        void Load();
        void Show();
        event Action AdLoaded;
        event Action AdFailed;
        event Action AdDismissedFullScreenContent;
        event Action AdFailedToShowFullScreenContent;
        event Action AdShowedFullScreenContent;
    }
}
