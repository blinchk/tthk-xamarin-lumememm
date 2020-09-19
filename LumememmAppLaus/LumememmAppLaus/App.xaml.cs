using Xamarin.Forms;

namespace LumememmAppLaus
{
    public partial class App
    {
        public App()
        {
            Device.SetFlags(new[] { "Shapes_Experimental", "Brush_Experimental" });
            InitializeComponent();
            MainPage = new AbsolutePage();
            // MainPage = new MainPage();
            MainPage = new NavigationPage(new AbsolutePage());
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
