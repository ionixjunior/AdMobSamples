using System;

namespace AdMobCross.Interfaces
{
    public interface IAdInterstitial
    {
        void Load();
        void Show();
        event Action AdLoaded;
        event Action AdFailed;
    }
}
