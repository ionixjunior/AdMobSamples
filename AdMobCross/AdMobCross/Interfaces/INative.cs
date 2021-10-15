using System;
using AdMobCross.Models;

namespace AdMobCross.Interfaces
{
    public interface INative : IDisposable
    {
        void Load(string adId, int numberOfAds);
        event Action<NativeAd> AdLoaded;
    }
}
