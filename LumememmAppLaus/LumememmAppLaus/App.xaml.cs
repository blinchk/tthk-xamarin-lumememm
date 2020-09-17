using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LumememmAppLaus
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            
            MainPage = new AbsolutePage();
            // MainPage = new NavigationPage(new MainPage());
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
