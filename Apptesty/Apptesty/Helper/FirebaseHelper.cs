using System;
using System.Collections.Generic;
using System.Text;

using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Apptesty.Model;

namespace XamarinFirebase.Helper
{

    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://allabeed-default-rtdb.firebaseio.com/");

        public async Task<List<Person>> GetAllPersons()
        {

            return (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Select(item => new Person
              {
                  Name = item.Object.Name,
                  PersonId = item.Object.PersonId,
                  PointNum=item.Object.PointNum,
                  PhNum= item.Object.PhNum
              }).ToList();
        }
        public async Task AddPerson(int personId, string name, int pointNum, string phNum)
        {

            await firebase
              .Child("Persons")
              .PostAsync(new Person() { PersonId = personId, Name = name, PointNum = pointNum, PhNum = phNum});
        }

        public async Task<Person> GetPerson(int personId)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("Persons")
              .OnceAsync<Person>();
            return allPersons.Where(a => a.PersonId == personId).FirstOrDefault();
        }

        public async Task UpdatePerson(int personId, string name, int pointNum, string phNum)
        {
            var toUpdatePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();

            await firebase
              .Child("Persons")
              .Child(toUpdatePerson.Key)
              .PutAsync(new Person() { PersonId = personId, Name = name, PointNum = pointNum, PhNum = phNum });
        }

        public async Task DeletePerson(int personId)
        {
            var toDeletePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();
            await firebase.Child("Persons").Child(toDeletePerson.Key).DeleteAsync();

        }
    }
}