using System;
using AdMobCross.Interfaces;
using Google.MobileAds;

namespace AdMobCross.iOS.Implementations
{
    public class InterstitialiOS : IInterstitial
    {
        private Interstitial? _interstitialAd;
        public event Action AdLoaded;
        public event Action AdFailed;
        public event Action AdDismissedFullScreenContent;
        public event Action AdFailedToShowFullScreenContent;
        public event Action AdShowedFullScreenContent;

        public void Load(string adId)
        {
            var request = Request.GetDefaultRequest();
            _interstitialAd = new Interstitial(adId);
            _interstitialAd.AdReceived += OnAdReceived;
            _interstitialAd.ReceiveAdFailed += OnReceiveAdFailed;
            _interstitialAd.ScreenDismissed += OnWillDismissScreen;
            _interstitialAd.FailedToPresentScreen += OnFailedToPresentScreen;
            _interstitialAd.WillPresentScreen += OnWillPresentScreen;
            _interstitialAd.LoadRequest(request);
        }

        private void OnAdReceived(object _, EventArgs __)
        {
            AdLoaded?.Invoke();
        }

        private void OnReceiveAdFailed(object _, EventArgs __)
        {
            AdFailed?.Invoke();
        }

        private void OnWillDismissScreen(object _, EventArgs __)
        {
            AdDismissedFullScreenContent?.Invoke();
        }

        private void OnFailedToPresentScreen(object _, EventArgs __)
        {
            AdFailedToShowFullScreenContent?.Invoke();
        }

        private void OnWillPresentScreen(object _, EventArgs __)
        {
            AdShowedFullScreenContent?.Invoke();
            _interstitialAd = null;
        }

        public void Show()
        {
            _interstitialAd?.Present(Xamarin.Essentials.Platform.GetCurrentUIViewController());
        }
    }
}
