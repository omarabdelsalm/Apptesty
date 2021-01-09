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
                Url = "https://elaabed611.blogspot.com/search/label/%D8%AE%D8%AF%D9%85%D8%A7%D8%AA%20%D9%83%D8%A7%D8%B4%20%D9%88%D8%AA%D9%82%D8%B3%D9%8A%D8%B7"
            }) ;
            Monkeys.Add(new Monkey
            {
                Name = "تابعنا على فيسبوك",
                Location = "العابد",
                ImageUrl = "ph.jpg",
                Url = "https://www.facebook.com/elabeed2587"
            });
            Monkeys.Add(new Monkey
            {
                Name = "اكسسوارات المحمول",
                Location = "بسعر الجملة",
                ImageUrl = "ac.jpg",
                Url= "https://elaabed611.blogspot.com/search/label/%D8%A7%D9%83%D8%B3%D8%B3%D9%88%D8%A7%D8%B1%D8%A7%D8%AA"
            });
            Monkeys.Add(new Monkey
            {
                Name = "اكسسوارات شركة كورن",
                Location = "كورن",
                ImageUrl = "ac.jpg",
                Url = "https://elaabed611.blogspot.com/search/label/%D8%A7%D9%83%D8%B3%D8%B3%D9%88%D8%B1%D8%A7%20%D8%B4%D8%B1%D9%83%D8%A9%20%D9%83%D9%88%D8%B1%D9%86"
            });
           
            Monkeys.Add(new Monkey
            {
                Name = "منتجات شركة كورن",
                Location = "كورن",
                ImageUrl = "ac.jpg",
                Url = "https://elaabed611.blogspot.com/search/label/%D9%85%D9%86%D8%AA%D8%AC%D8%A7%D8%AA%20%D8%B4%D8%B1%D9%83%D8%A9%20%D9%83%D9%88%D8%B1%D9%86%20%D8%A8%D8%A7%D9%84%D8%B6%D9%85%D8%A7%D9%86"
            });
            Monkeys.Add(new Monkey
            {
                Name = "تحويلات وهوائي",
                Location = "كل الخطوط",
                ImageUrl = "ab.gpj",
                Url = "https://elaabed611.blogspot.com/search/label/%D9%85%D8%AD%D9%85%D9%88%D9%84"
            }) ;
            Monkeys.Add(new Monkey
            {
                Name = "Oppo",
                Location = "كل انواع اوبو",
                ImageUrl = "oppoa73.jpg",
                Url= "https://elaabed611.blogspot.com/search/label/oppo"
            });
            Monkeys.Add(new Monkey
            {
                Name = "Huawei",
                Location = "كل انواع Huawei",
                ImageUrl = "huawei.jpg",
                Url = "https://www.facebook.com/elabeed2587"
            });
            Monkeys.Add(new Monkey
            {
                Name = "Realme",
                Location = "كل انواع Realme",
                ImageUrl = "Realme.jpg",
                Url= "https://elaabed611.blogspot.com/search/label/Realme"
            });
            Monkeys.Add(new Monkey
            {
                Name = "Iphone",
                Location = "كل انواع Iphone ",
                ImageUrl = "iphone.jpg",
                Url = "https://www.facebook.com/elabeed2587"
            });
            Monkeys.Add(new Monkey
            {
                Name = "Samsung",
                Location = "كل انواع Samsung",
                ImageUrl = "samsung.jpg",
                Url = "https://elaabed611.blogspot.com/search/label/%D8%B3%D8%A7%D9%85%D8%B3%D9%88%D9%86%D8%AC"
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
