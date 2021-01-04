using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    Heading ="Mountains",
                    Caption = "Explore the world from your own point of view. Visit mountains and enjoy the freshness of life.",
                    Image = "ac.png"
                },

                new Walkthrough
                {
                    Heading ="Cities",
                    Caption = "Experience the blue and grey sights of high rise buildings around the world",
                    Image = "i11.png"
                },

                new Walkthrough
                {
                    Heading ="Ancient",
                    Caption = "Understand the history and heritage of different cultures around the world.",
                    Image = "ae.png"
                }
            });
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListPage());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OnePage());
        }
    }

    public class Walkthrough
    {
        public string Heading { get; set; }
        public string Caption { get; set; }
        public string Image { get; set; }
    }
}
