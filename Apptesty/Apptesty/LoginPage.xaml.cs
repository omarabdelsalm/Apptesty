using Firebase.Auth;
using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Apptesty
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public string WebAPIkey = "AIzaSyArAP9Qj8nVl9KKaRDzwVy6M3ImeO0EvQY";
        public LoginPage()
        {
            InitializeComponent();
            this.bannerAd_view2.AdsId = AdmobUnitIds.BannerId;
            UserNewEmail.Completed += (object sender, EventArgs e) =>
            {
                _ = UserNewPassword.Focus();
            };
        }


        async void signupbutton_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(UserNewEmail.Text, UserNewPassword.Text);
                string gettoken = auth.FirebaseToken;
                await App.Current.MainPage.DisplayAlert("Alert", "تم تسجيل حسابك بنجاح", "Ok");
                await Navigation.PushAsync(new SigininPage());
                UserNewEmail.Placeholder = "Email";
                UserNewPassword.Placeholder = "Pasword";

            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "الرجاء التاكد من الايميل والباسورد", "OK");
            }

        }
        
    }
}