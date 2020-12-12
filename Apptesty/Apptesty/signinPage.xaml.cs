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
    public partial class SigininPage : ContentPage
    {
        public string WebAPIkey = "AIzaSyArAP9Qj8nVl9KKaRDzwVy6M3ImeO0EvQY";
       
        public SigininPage()
        {
            InitializeComponent();
            UserLoginEmail.Completed += (object sender, EventArgs e) =>
            {
                _ = UserLoginPassword.Focus();
            };
        }

        

        async void loginbutton_Clicked(System.Object sender, System.EventArgs e)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserLoginEmail.Text, UserLoginPassword.Text);
                var content = await auth.GetFreshAuthAsync();
                var serializedcontnet = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);
                if (UserLoginEmail.Text=="bkr@bkr.com "|| UserLoginPassword.Text=="bkr123")
                {
                    
                    await Navigation.PushAsync(new UsersPage());
                }
                else
                {
                   

                    await Navigation.PushAsync(new MainPage());
                }
                
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "ايميل وباسوردغير مطابق", "OK");
            }
        }
       
    }
}