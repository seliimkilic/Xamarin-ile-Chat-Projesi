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
    public partial class ChatPage : ContentPage
    {
        DBFire db = new DBFire();
        Room rm = new Room();
        public ChatPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<RoomPage, Room>(this, "RoomProp", (page, data) => {

                rm = data;
                _lstChat.BindingContext = db.subChat(data.Key);
                MessagingCenter.Unsubscribe<RoomPage, Room>(this, "RoomProp");
            });
            
        }

        async void denemeler(object sender, System.EventArgs e)
        {
            var chatOBJ = new Chat { UserMessage = _etMessage.Text, UserName = User.UserName };
            await db.SaveMessage(chatOBJ, rm.Key);
            
        }
    }
}