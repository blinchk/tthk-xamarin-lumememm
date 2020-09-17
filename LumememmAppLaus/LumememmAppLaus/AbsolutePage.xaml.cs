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
            Title = "Lumememm";
            // InitializeComponent();
            AbsoluteLayout absoluteLayout = new AbsoluteLayout() { BackgroundColor = Color.Orange };

            for (int i = 0; i < 3; i++)
            {
                BoxView x = new BoxView { Color = Color.White, CornerRadius = 100 + (i*10)};
                AbsoluteLayout.SetLayoutBounds(x, new Rectangle(0.5, 0.05+(i*0.37), 200 + 25 * i, 200 + 25 * i));
                AbsoluteLayout.SetLayoutFlags(x, AbsoluteLayoutFlags.PositionProportional);
                absoluteLayout.Children.Add(x);
                if (i == 2) {
                    for (int j = 1; j < 4; j++)
                    {
                        BoxView y = new BoxView { Color = Color.Black, CornerRadius = 10 };
                        AbsoluteLayout.SetLayoutBounds(y, new Rectangle(0.5, 1 / j, 20, 20));
                        AbsoluteLayout.SetLayoutFlags(y, AbsoluteLayoutFlags.PositionProportional);
                        absoluteLayout.Children.Add(x, y.Bounds, AbsoluteLayoutFlags.None);
                    }
                }
            }

            Content = absoluteLayout;
        }
    }
}