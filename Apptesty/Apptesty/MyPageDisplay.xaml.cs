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
    public partial class MyPageDisplay : ContentPage
    {
        ListPage lest= new ListPage();
        string w = "";
        public MyPageDisplay()
        {
            InitializeComponent();
            Monkey bnm = new Monkey();
            ListPage lest = new ListPage();

            //string w =  bnm.Url;
            //string we = lest.ToString(w);
            //var we = l.Monkeys.w.Url;
            MyWebviewDisplay.Source = "bnm.Url";
        }
    }
}