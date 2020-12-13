using Apptesty.Model;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFirebase.Helper;
using ZXing.Net.Mobile.Forms;
using ZXing.PDF417.Internal;

namespace Apptesty
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MamPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        FirebaseClient firebase = new FirebaseClient("https://allabeed-default-rtdb.firebaseio.com/");

        Person persons = new Person();
        public static object ItemTapped { get; private set; }
        public MamPage()
        {
            InitializeComponent();
            
        }

        protected async override void OnAppearing()
        {
            //ListView listvw = new ListView();
            
            base.OnAppearing();
            var allPersons = await firebaseHelper.GetAllPersons();
            listvw.ItemsSource = allPersons;

        }
        
        private async void SearchBar_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            //MyListCollector=new  ObservableCollection<Person>();
            var allPersons = await firebaseHelper.GetAllPersons();
            listvw.ItemsSource = allPersons;
           // var _container = BindingContext as Person;
            listvw.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                //listvw.ItemsSource = _container.MyListCollector;
                listvw.ItemsSource = allPersons;
            else
                //listvw.ItemsSource = _container.MyListCollector.Where(i => i.MyName.Contains(e.NewTextValue));
            listvw.ItemsSource = allPersons.Where(i => i.Name.Contains(e.NewTextValue));


            listvw.EndRefresh();
        }
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            _ = BindingContext as Person;
            //do work over here
            DisplayAlert("Sucess", "You have Subscribed", "OK", "Cancel");
        }

        private async void listvw_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var allPersons = await firebaseHelper.GetAllPersons();
            listvw.ItemsSource = allPersons;
            ListView lv = (ListView)sender;

            //// this assumes your List is bound to a List<Club>

            persons= (Person)lv.SelectedItem;


            await Navigation.PushAsync(new MyPageDisplays(persons.PersonId.ToString(), persons.Name.ToString(), persons.PhNum.ToString(), persons.PointNum2.ToString()));
        }
        //اضافة صفحة لعرض العنصر الموجود فى القائمة
        //private void Listvw_ItemTapped(object sender, SelectedItemChangedEventArgs e)
        //{
        //    _ = e.SelectedItem as Person;

        //}

    }
}