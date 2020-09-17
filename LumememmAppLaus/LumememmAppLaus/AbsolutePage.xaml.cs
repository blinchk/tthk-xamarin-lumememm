using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LumememmAppLaus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AbsolutePage : ContentPage
    {
        public AbsolutePage()
        {
            // InitializeComponent();
            AbsoluteLayout absoluteLayout = new AbsoluteLayout();
            BoxView firstBall = new BoxView { Color = Color.White, CornerRadius=50 };
            
            Content = absoluteLayout;
        }
    }
}