using CevikTeknikChat.Design;
using CevikTeknikChat.View;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CevikTeknikChat.PopupPagess
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPopupPg : PopupPage
    {
        public MyPopupPg()
        {
            InitializeComponent();
        }

         void giris(object sender,EventArgs e)
        {
            User.UserName = _username.Text;
            //Navigation.PopPopupAsync();
            Navigation.PushAsync(new RoomPage());
        }

    }
}