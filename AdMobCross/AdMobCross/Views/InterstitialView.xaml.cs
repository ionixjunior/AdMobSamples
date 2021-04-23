using System;
using System.Collections.Generic;
using AdMobCross.Interfaces;
using Xamarin.Forms;

namespace AdMobCross.Views
{
    public partial class InterstitialView : ContentPage
    {
        private readonly IAdInterstitial _adInterstitial;

        public InterstitialView()
        {
            InitializeComponent();
            _adInterstitial = DependencyService.Get<IAdInterstitial>();
            _adInterstitial.AdLoaded += OnAdLoaded;
            _adInterstitial.AdFailed += OnAdFailed;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

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
    }
}
