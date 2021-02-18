using MarcTron.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Apptesty
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OnePage : ContentPage
    {
        public OnePage()
        {
            InitializeComponent();
            this.bannerAd_view2.AdsId = AdmobUnitIds.BannerId;
            this.bannerAd_view.AdsId = AdmobUnitIds.BannerId;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.LoadInterstitial(AdmobUnitIds.InterstitialId);
            CrossMTAdmob.Current.ShowInterstitial();
            await Navigation.PushAsync(new SigininPage());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.LoadInterstitial(AdmobUnitIds.InterstitialId);
            CrossMTAdmob.Current.ShowInterstitial();
            await Navigation.PushAsync(new LoginPage());
        }
    }
}