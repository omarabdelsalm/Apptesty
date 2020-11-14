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

        Contactpage c = new Contactpage();
        private static object SelectedItem;
        private static IFormatProvider MyWebviewDisplay;
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
                ImageUrl = "ab.jpg"
            });
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
                Url = "www.blogger.com"
            });
            BindingContext = this;
        }

         void  OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _ = e.SelectedItem as Monkey;
           
        }

        void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            _ = e.Item as Monkey;
            MyPageDisplay mydisview = new MyPageDisplay();
            mydisview.BindingContext = e.ToString();
            //var v = mydisview.InputTransparent.ToString(MyWebviewDisplay);
             Navigation.PushAsync(mydisview);
        }

        //private static async MyPageDisplay NewMethod(ItemTappedEventArgs e)
        //{
        //    mydisview.BindingContext = e.ToString();
        //    string v = mydisview.InputTransparent.ToString(MyWebviewDisplay);
        //    return await Navigation.PushAsync(mydisview);

        //}

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(c);
        }
    }

    
}
