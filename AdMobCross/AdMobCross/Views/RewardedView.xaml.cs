using System;
using AdMobCross.Interfaces;
using Xamarin.Forms;

namespace AdMobCross.Views
{
    public partial class RewardedView : ContentPage, ILifecycleLite
    {
        private readonly IRewarded _adRewarded;

        public RewardedView()
        {
            InitializeComponent();
            _adRewarded = DependencyService.Get<IRewarded>();
            _adRewarded?.Load(Constants.AdRewardedId);
        }

        public void OnCreated()
        {
            System.Diagnostics.Debug.WriteLine("A tela abriu!");
            _adRewarded.AdLoaded += OnAdLoaded;
            _adRewarded.AdFailed += OnAdFailed;
            _adRewarded.AdDismissedFullScreenContent += OnAdDismissedFullScreenContent;
            _adRewarded.AdFailedToShowFullScreenContent += OnAdFailedToShowFullScreenContent;
            _adRewarded.AdShowedFullScreenContent += OnAdShowedFullScreenContent;
            _adRewarded.AdEarnReward += OnAdEarnReward;
        }

        public void OnDestroyed()
        {
            System.Diagnostics.Debug.WriteLine("A tela foi destruida!");
            _adRewarded.AdLoaded -= OnAdLoaded;
            _adRewarded.AdFailed -= OnAdFailed;
            _adRewarded.AdDismissedFullScreenContent -= OnAdDismissedFullScreenContent;
            _adRewarded.AdFailedToShowFullScreenContent -= OnAdFailedToShowFullScreenContent;
            _adRewarded.AdShowedFullScreenContent -= OnAdShowedFullScreenContent;
            _adRewarded.AdEarnReward -= OnAdEarnReward;
        }

        private void OnAdLoaded()
        {
            System.Diagnostics.Debug.WriteLine("A propaganda está pronta para ser usada na tela");
        }

        private void OnAdFailed()
        {
            System.Diagnostics.Debug.WriteLine("A propaganda não pode ser carregada na tela");
        }

        private void OnAdDismissedFullScreenContent()
        {
            System.Diagnostics.Debug.WriteLine("A propaganda foi descartada da tela");
        }

        private void OnAdFailedToShowFullScreenContent()
        {
            System.Diagnostics.Debug.WriteLine("A propaganda falhou ao ser exibida na tela");
        }

        private void OnAdShowedFullScreenContent()
        {
            System.Diagnostics.Debug.WriteLine("A propaganda foi exibida na tela");
        }

        private void OnAdEarnReward()
        {
            System.Diagnostics.Debug.WriteLine("Ganhou um prêmio!");
        }

        private void AoClicarEmMostrar(object _, EventArgs __)
        {
            _adRewarded?.Show();
        }
    }
}
