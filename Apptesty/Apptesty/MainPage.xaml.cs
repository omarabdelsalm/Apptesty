using MarcTron.Plugin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Apptesty
{
    public partial class MainPage : ContentPage
    {
        private void Handle_Navigated(object sender, Xamarin.Forms.WebNavigatedEventArgs e)
        {
            LoadingLabel.IsVisible = false;
        }

        private void Handle_Navigating(object sender, Xamarin.Forms.WebNavigatingEventArgs e)
        {
            LoadingLabel.IsVisible = true;
        }

        //void Go_Clicked(object sender, System.EventArgs e)
        //{
        //    Browser.Source = url.Text;
        //}

        private void Forward_Clicked(object sender, System.EventArgs e)
        {
            if (Browser.CanGoForward)
                Browser.GoForward();
        }

        private void Back_Clicked(object sender, System.EventArgs e)
        {
            if (Browser.CanGoBack)
                Browser.GoBack();
        }

        private ListPage p = new ListPage();
        public MainPage()
        {
            InitializeComponent();
            //url.Text = "https://elaabed611.blogspot.com/";

            Browser.Source = "https://elaabed611.blogspot.com/";
            nxt_Clicked.Clicked += Nxt_Clicked;
            this.bannerAd_view2.AdsId = AdmobUnitIds.BannerId;
        }

        private async void Nxt_Clicked(object sender, EventArgs e)
        {
            MarcTron.Plugin.CrossMTAdmob.Current.LoadRewardedVideo(AdmobUnitIds.RewardedId);
            await Navigation.PushAsync(p);
        }
        private async void Btn_Clicked(object sender, EventArgs e)
        {
			CrossMTAdmob.Current.ShowInterstitial();
            await Navigation.PushAsync(new MamPage());
        }
    }
}
