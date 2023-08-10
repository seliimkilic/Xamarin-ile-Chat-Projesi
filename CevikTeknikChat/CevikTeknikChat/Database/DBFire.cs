using CevikTeknikChat.Model;
using Firebase.Database;
using Firebase.Database.Query;
//using Firebase.Xamarin.Database;
//using Firebase.Xamarin.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CevikTeknikChat.Database
{
     public class DBFire
    {
        FirebaseClient fbClient;
        public DBFire()
        {
            fbClient = new FirebaseClient("https://cevikteknikmetal-5a5cf-default-rtdb.firebaseio.com/");
        }
        public async Task<List<Room>> getRoomList()
        {
            return (await fbClient
                .Child("Chatapp")
                .OnceAsync<Room>())
                .Select((item) =>
                new Room
                {
                    Key = item.Key,
                    Name = item.Object.Name    
                }
                ).ToList(); 

        }

        public async Task SaveRoom(Room rm)
        {
             await fbClient.Child("Chatapp")
                .PostAsync(rm);
        }
       


        public async Task SaveMessage(Chat _ch , string _room)
        {
           await fbClient.Child("Chatapp/" + _room + "/Message")
                .PostAsync(_ch);
        }

        public ObservableCollection<Chat> subChat(string _roomKEY)
        {
            return fbClient.Child("Chatapp/"+_roomKEY+"/Message")
                .AsObservable<Chat>()
                .AsObservableCollection<Chat>(); 
        }

    }
}
