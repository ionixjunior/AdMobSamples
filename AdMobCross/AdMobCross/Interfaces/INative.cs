using System;
using AdMobCross.Models;

namespace AdMobCross.Interfaces
{
    public interface INative
    {
        void Load(string adId, int numberOfAds);
        event Action<NativeAd> AdLoaded;
    }
}
