using CevikTeknikChat.Database;
using CevikTeknikChat.Design;
using CevikTeknikChat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CevikTeknikChat.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoomPage : ContentPage
    {
        DBFire db = new DBFire();
        protected override async void OnAppearing()
        {
            base.OnAppearing();
           
            var list = await db.getRoomList();
            _lstx.BindingContext = list;
        }
        public RoomPage()
        {
            InitializeComponent();
        }

         void ekle(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddRoomPage());
        }

        void ekleme(object sender, System.EventArgs e)
        {
            DisplayAlert("Current User", User.UserName, "Okey");
        }

        async void deneme(object sender, System.EventArgs e)
        {
            _lstx.BindingContext = await db.getRoomList();
            _lstx.IsRefreshing = false;
        }

        void secme (object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (_lstx.SelectedItem!=null)
            {
                var selectRoom = (Room)_lstx.SelectedItem;
                Navigation.PushAsync(new ChatPage());
                MessagingCenter.Send<RoomPage, Room>(this, "RoomProp", selectRoom);
                
            }
        }

    }
}