using CevikTeknikChat.Database;
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
    public partial class AddRoomPage : ContentPage
    {
        public AddRoomPage()
        {
            InitializeComponent();
        }
       async void dd (object sender, System.EventArgs e)
        {
           var db = new DBFire();
           await db.SaveRoom(new Room() { Name = _rootname.Text });
           await Navigation.PopAsync();
        }
    }
}