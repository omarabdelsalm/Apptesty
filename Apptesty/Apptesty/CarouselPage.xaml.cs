using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarcTron.Plugin;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Apptesty
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarouselPage : ContentPage
    {
        public CarouselPage()
        {
            InitializeComponent();
            this.BindingContext = this;
            this.bannerAd_view.AdsId = AdmobUnitIds.BannerId;
            this.bannerAd_view2.AdsId = AdmobUnitIds.BannerId;
        }

        private Timer timer;

        public ObservableCollection<Walkthrough> WalkthroughItems { get => Load(); }


        protected override void OnAppearing()
        {
            timer = new Timer(TimeSpan.FromSeconds(5).TotalMilliseconds) { AutoReset = true, Enabled = true };
            timer.Elapsed += Timer_Elapsed;
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            timer?.Dispose();
            base.OnDisappearing();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {

                if (cvWalkthrough.Position == 2)
                {
                    cvWalkthrough.Position = 0;
                    return;
                }

                cvWalkthrough.Position += 1;
            });
        }

        private ObservableCollection<Walkthrough> Load()
        {
            return new ObservableCollection<Walkthrough>(new[]
            {
                new Walkthrough
                {
                    Heading ="العابد",
                    Caption = "من افتتاح العابد وثقة الناس",
                    Image = "en.jpg"
                },

                new Walkthrough
                {
                    Heading ="كورن",
                    Caption = "استمتع باجمل اللحظات مع سماعات كورن",
                    Image = "nn.jpg"
                },

                new Walkthrough
                {
                    Heading ="سماعات",
                    Caption = "افضل واحدث اكسسوارات من العابد",
                    Image = "n.jpg"
                }
            });
        }

        //private async void Button_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new ListPage());
        //}

        //private async void Button_Clicked_1(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new OnePage());
        //}

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListPage());
            CrossMTAdmob.Current.LoadRewardedVideo(AdmobUnitIds.RewardedId);
        }

        private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.LoadInterstitial(AdmobUnitIds.InterstitialId);
            await Navigation.PushAsync(new OnePage());
        }

        private async void ToolbarItem_Clicked_2(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.ShowInterstitial();
            await Navigation.PushAsync(new Contactpage());
        }
    }

    public class Walkthrough
    {
        public string Heading { get; set; }
        public string Caption { get; set; }
        public string Image { get; set; }
    }
}
