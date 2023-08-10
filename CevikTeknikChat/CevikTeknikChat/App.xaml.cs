using CevikTeknikChat.PopupPagess;
using CevikTeknikChat.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CevikTeknikChat
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new MyPopupPg());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
