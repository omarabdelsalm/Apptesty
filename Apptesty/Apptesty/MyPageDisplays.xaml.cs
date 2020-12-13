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
    public partial class MyPageDisplays : ContentPage
    {
        public MyPageDisplays(string person,string name,string phon,string point)
        {
            InitializeComponent();
            perId.Text = person;
            nameEt.Text = name;
            phonEt.Text = phon;
            pointEt.Text = point;


        }
    }
}