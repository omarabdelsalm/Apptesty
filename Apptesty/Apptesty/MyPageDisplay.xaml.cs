using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Apptesty
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPageDisplay : ContentPage
    {
        public MyPageDisplay(string url,string name)
        {
          InitializeComponent();
            this.bannerAd_view.AdsId = AdmobUnitIds.BannerId;

            
            myLab.Text = name;
            MyWebviewDisplay.Source = url;
        }

        
    }
}