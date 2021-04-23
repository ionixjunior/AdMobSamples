using System;
using System.Collections.Generic;
using AdMobCross.Interfaces;
using Xamarin.Forms;

namespace AdMobCross.Views
{
    public partial class InterstitialView : ContentPage, ILifecycleLite
    {
        private readonly IInterstitial _adInterstitial;

        public InterstitialView()
        {
            InitializeComponent();
            _adInterstitial = DependencyService.Get<IInterstitial>();
            _adInterstitial.AdLoaded += OnAdLoaded;
            _adInterstitial.AdFailed += OnAdFailed;
            _adInterstitial.AdDismissedFullScreenContent += OnAdDismissedFullScreenContent;
            _adInterstitial.AdFailedToShowFullScreenContent += OnAdFailedToShowFullScreenContent;
            _adInterstitial.AdShowedFullScreenContent += OnAdShowedFullScreenContent;
            _adInterstitial?.Load();
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

        private void AoClicarEmMostrar(object _, EventArgs __)
        {
            _adInterstitial?.Show();
            //_adInterstitial.AdLoaded -= OnAdLoaded;
            //_adInterstitial.AdFailed -= OnAdFailed;
        }

        public void OnCreated()
        {
            System.Diagnostics.Debug.WriteLine("A tela abriu!");
        }

        public void OnDestroyed()
        {
            System.Diagnostics.Debug.WriteLine("A tela foi destruida!");
        }
    }
}
