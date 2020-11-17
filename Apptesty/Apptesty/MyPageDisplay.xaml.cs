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
        public MyPageDisplay()
        {
          InitializeComponent();

            //ListPage lest = new ListPage();
            //List<Monkey> lists = new List<Monkey>();
            //Monkeys = lists;
            //// string url = Monkeys.ItemTapped.Url.ToString();
            //MyWebviewDisplay.Source = new UrlWebViewSource
            //{
            //    Url = "Monkeys.Url"
            //};
            //MyWebviewDisplay.Source = DependencyService.Get<IwebSiteHelper>() + "{Binding Url}";
            //MyWebviewDisplay.Source = "{Binding monkeys.Url}";
        }

        
    }
}