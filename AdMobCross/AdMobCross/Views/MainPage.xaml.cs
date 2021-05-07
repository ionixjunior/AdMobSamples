using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AdMobCross.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnBannerClicked(object _, EventArgs __)
        {
            await Navigation.PushAsync(new BannerView());
        }

        private async void OnInterstitialClicked(object _, EventArgs __)
        {
            await Navigation.PushAsync(new InterstitialView());
        }

        private async void OnRewardedClicked(object _, EventArgs __)
        {
            await Navigation.PushAsync(new RewardedView());
        }
    }
}
