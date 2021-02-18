using Apptesty.Model;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFirebase.Helper;
using Firebase.Database;
using Firebase.Database.Query;
using ZXing.Net.Mobile.Forms;
using Apptesty.Server.Views;
using MarcTron.Plugin;

namespace Apptesty
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        FirebaseClient firebase = new FirebaseClient("https://allabeed-default-rtdb.firebaseio.com/");
        MamPage mo = new MamPage();
        public UsersPage()
        {
            InitializeComponent();
            
            
        }

        protected async override void OnAppearing()
        {
          

            base.OnAppearing();
            var allPersons = await firebaseHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
            txtId.Completed += (object sender, EventArgs e) =>
            {
                _ = txtName.Focus();
            };
            txtName.Completed += (object sender, EventArgs e) =>
            {
                _ = txtPoint1.Focus();
            };
            txtPoint.Completed += (object sender, EventArgs e) =>
            {
                _ = txtPoint1.Focus();
            };
            txtPoint1.Completed += (object sender, EventArgs e) =>
            {
                _ = txtPh.Focus();
            };
        }
        public async Task AddPerson(long personId, string name)
        {

            await firebase
              .Child("Persons")
              .PostAsync(new Person() { PersonId = personId, Name = name });
        }
        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.AddPerson((int)Convert.ToInt64(txtId.Text), txtName.Text, Convert.ToInt32(txtPoint.Text), Convert.ToInt32(txtPoint1.Text) + Convert.ToInt32(txtPoint.Text), Convert.ToInt32(txtPoint2.Text), txtPh.Text);
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPoint.Text = string.Empty;
            txtPoint1.Text = string.Empty;
            txtPoint2.Text = string.Empty;
            txtPh.Text = string.Empty;
            await DisplayAlert("Success", "Person Added Successfully", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }

        private async void BtnRetrive_Clicked(object sender, EventArgs e)
        {
           
            btnAdd.IsEnabled = false;
            //txtName.IsReadOnly = true;
            //txtPoint.IsReadOnly = true;
            //txtPh.IsReadOnly = true;
            var person = await firebaseHelper.GetPerson((int)Convert.ToInt64(txtId.Text));
                if (person != null)
                //if (txtId.Text == (long)Entry) { }
                {
                    txtId.Text = person.PersonId.ToString();
                    txtName.Text = person.Name;
                txtPh.Text = person.PhNum;
                txtPoint.Text = person.PointNum.ToString();
                txtPoint1.Text="";
                txtPoint2.Text = person.PointNum2.ToString();
                await DisplayAlert("Success", "تم استعادة الاسم", "OK");
                
            }
                else
                {
                    await DisplayAlert("Success", "لا يوجد اعضاء لهذا الباركود", "OK");
                }

           
            
        }

        public async Task UpdatePerson(long personId, string name,string phNum,int pointNum1,int pointNum2,int pointNum)
        {
            var person = await firebaseHelper.GetPerson((int)Convert.ToInt64(txtId.Text));

            txtPoint.Text = person.PointNum2.ToString();
            var toUpdatePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();

            await firebase
              .Child("Persons")
              .Child(toUpdatePerson.Key)
              .PutAsync(new Person() { PersonId = personId, Name = name,  PointNum2 = pointNum+pointNum1, PhNum = phNum });
            
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            btnDelete.IsEnabled = true;
            btnAdd.IsEnabled = true;
            await firebaseHelper.UpdatePerson((int)Convert.ToInt64(txtId.Text), txtName.Text, Convert.ToInt32(txtPoint.Text), Convert.ToInt32(txtPoint1.Text), Convert.ToInt32(txtPoint2.Text), txtPh.Text);
           
            await DisplayAlert("Success", "تم تحديث الاسم بنجاح", "OK");
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPoint.Text = string.Empty;
            txtPoint2.Text = string.Empty;
            txtPoint1.Text = string.Empty;
            txtPh.Text = string.Empty;
            txtId.Focus();
            var allPersons = await firebaseHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }
        public async Task DeletePerson(long personId)
        {
            btnDelete.IsEnabled = true;
            btnAdd.IsEnabled = true;
            var toDeletePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();
            await firebase.Child("Persons").Child(toDeletePerson.Key).DeleteAsync();

        }

        //Delete person حذف العضو
        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            var person = await firebaseHelper.GetPerson((int)Convert.ToInt64(txtId.Text));
            if (person != null) {
                await firebaseHelper.DeletePerson(Convert.ToInt32(txtId.Text));
                await DisplayAlert("Success", "تم حذف الاسم", "OK");
                txtId.Text = string.Empty;
                txtName.Text = string.Empty;
                txtPoint.Text = string.Empty;
                txtPoint1.Text = string.Empty;
                txtPoint2.Text = string.Empty;
                txtPh.Text = string.Empty;

                txtId.Focus();
                var allPersons = await firebaseHelper.GetAllPersons();
                lstPersons.ItemsSource = allPersons;
            }
            else
            {
                await DisplayAlert("انتباه", "رجاء ادخل بيانات العضو ", "OK");
                txtId.Focus();
            }
                
          
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var scan = new ZXingScannerPage();
            await Navigation.PushAsync(scan);
            scan.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    txtId.Text = result.Text;
                });
            };
               
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.LoadInterstitial(AdmobUnitIds.InterstitialId);
            CrossMTAdmob.Current.ShowInterstitial();
            await Navigation.PushAsync(new MainPage());
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            mo.IsVisible = true;
            CrossMTAdmob.Current.LoadInterstitial(AdmobUnitIds.InterstitialId);
            CrossMTAdmob.Current.ShowInterstitial();
            await Navigation.PushAsync(new MamPage());

        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.LoadInterstitial(AdmobUnitIds.InterstitialId);
            CrossMTAdmob.Current.ShowInterstitial();
            await Navigation.PushAsync(new AdminNewsFeedPage());
        }
    }
}