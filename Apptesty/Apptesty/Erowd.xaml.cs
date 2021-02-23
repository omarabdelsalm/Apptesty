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
    public partial class Erowd : ContentPage
    {
        public Erowd()
        {
            InitializeComponent();
            this.bannerAd_view2.AdsId = AdmobUnitIds.BannerId;
        }
    }
}