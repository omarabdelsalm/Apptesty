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

namespace Apptesty
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MamPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        FirebaseClient firebase = new FirebaseClient("https://allabeed-default-rtdb.firebaseio.com/");

        public ObservableCollection<Person> MyListCollector { get; set; }

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
            var _container = BindingContext as Person;
            //do work over here
            DisplayAlert("Sucess", "You have Subscribed", "OK", "Cancel");
        }
    }
}