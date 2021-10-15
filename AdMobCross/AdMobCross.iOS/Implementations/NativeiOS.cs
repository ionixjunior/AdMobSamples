using System;
using AdMobCross.Interfaces;
using AdMobCross.Models;

namespace AdMobCross.iOS.Implementations
{
    public class NativeiOS : INative
    {
        public event Action<NativeAd> AdLoaded;

        public void Load(string adId, int numberOfAds)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
