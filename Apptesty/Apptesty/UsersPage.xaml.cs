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

namespace Apptesty
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        FirebaseClient firebase = new FirebaseClient("https://allabeed-default-rtdb.firebaseio.com/");
        public UsersPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allPersons = await firebaseHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }
        public async Task AddPerson(int personId, string name)
        {

            await firebase
              .Child("Persons")
              .PostAsync(new Person() { PersonId = personId, Name = name });
        }
        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.AddPerson(Convert.ToInt32(txtId.Text), txtName.Text, Convert.ToInt32(txtPoint.Text), txtPh.Text);
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            await DisplayAlert("Success", "Person Added Successfully", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }

        private async void BtnRetrive_Clicked(object sender, EventArgs e)
        {

            
                var person = await firebaseHelper.GetPerson(Convert.ToInt32(txtId.Text));
                if (person != null)
                {
                    txtId.Text = person.PersonId.ToString();
                    txtName.Text = person.Name;
                    await DisplayAlert("Success", "Person Retrive Successfully", "OK");

                }
                else
                {
                    await DisplayAlert("Success", "No Person Available", "OK");
                }

           
            
        }

        public async Task UpdatePerson(int personId, string name)
        {
            var toUpdatePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();

            await firebase
              .Child("Persons")
              .Child(toUpdatePerson.Key)
              .PutAsync(new Person() { PersonId = personId, Name = name });
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.UpdatePerson(Convert.ToInt32(txtId.Text), txtName.Text, Convert.ToInt32(txtPoint.Text),txtPh.Text);
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            await DisplayAlert("Success", "Person Updated Successfully", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }
        public async Task DeletePerson(int personId)
        {
            var toDeletePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();
            await firebase.Child("Persons").Child(toDeletePerson.Key).DeleteAsync();

        }


        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.DeletePerson(Convert.ToInt32(txtId.Text));
            await DisplayAlert("Success", "Person Deleted Successfully", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }


    }
}