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
    public partial class ListPage : ContentPage
    {
        public IList<Monkey> Monkeys { get; private set; }
        public static object ItemTapped { get; private set; }

        private Contactpage c = new Contactpage();
        //private MyPageDisplay Mypage = new MyPageDisplay();

        //private static object SelectedItem;
        // private static IFormatProvider MyWebviewDisplay;
        internal object lists;
        private static readonly Page mydisview;

        public ListPage()
        {
            InitializeComponent();
            nt_Clicked.Clicked += Btn_Clicked;
            List<Monkey> lists = new List<Monkey>();
            Monkeys = lists;
            Monkeys.Add(new Monkey
            {
                Name = "خدمات بيع",
                Location = "تقسيط وكاش",
                ImageUrl = "ab.jpg",
                Url = "https://www.google.com.eg/webhp?tab=rw"
            }) ;
            Monkeys.Add(new Monkey
            {
                Name = "اكسسوارات المحمول",
                Location = "بسعر الجملة",
                ImageUrl = "ac.jpg"
            });
            Monkeys.Add(new Monkey
            {
                Name = "تحويلات وهوائي",
                Location = "كل الخطوط",
                ImageUrl = "ab.gpj"
            });
            Monkeys.Add(new Monkey
            {
                Name = "Oppo",
                Location = "كل انواع اوبو",
                ImageUrl = "oppoa73.jpg"
            });
            Monkeys.Add(new Monkey
            {
                Name = "Huawei",
                Location = "كل انواع Huawei",
                ImageUrl = "huawei.jpg"
            });
            Monkeys.Add(new Monkey
            {
                Name = "Realme",
                Location = "كل انواع Realme",
                ImageUrl = "Realme.jpg"
            });
            Monkeys.Add(new Monkey
            {
                Name = "Iphone",
                Location = "كل انواع Iphone ",
                ImageUrl = "iphone.jpg"
            });
            Monkeys.Add(new Monkey
            {
                Name = "Samsung",
                Location = "كل انواع Samsung",
                ImageUrl = "samsung.jpg",
                Url = "https://www.google.com.eg/webhp?tab=rw"
            });
            BindingContext = this;
        }

        private void  OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _ = e.SelectedItem as Monkey;
           
        }

        //private async void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    var url = e.Item as Monkey;
        //    MyPageDisplay mydisview = new MyPageDisplay();
        //     //string MyWebviewDisplay = "";
        //    //mydisview.BindingContext = url.ToString();
        //    //mydisview.WebView ="url.Url";
        //    await Navigation.PushAsync(mydisview);
        //}
        async void OnListViewItemTapped(object sender, SelectedItemChangedEventArgs e)
        {

          ListView lv = (ListView)sender;

            //// this assumes your List is bound to a List<Club>
            Monkeys.Add(new Monkey {
                Url = this.ToString()

           });
            Monkey monkeys = (Monkey)lv.SelectedItem;
           

            await Navigation.PushAsync(new MyPageDisplay(monkeys.Url.ToString(),monkeys.Name.ToString()));
        }

       
        private async void Btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(c);
        }
    }

 
}
