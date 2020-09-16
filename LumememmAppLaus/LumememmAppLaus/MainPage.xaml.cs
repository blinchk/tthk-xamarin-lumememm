using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LumememmAppLaus
{
    public partial class MainPage : ContentPage
    {
        private Frame[] balls;
        public MainPage()
        {
            InitializeComponent();
            balls = new Frame[3] { firstBall, secondBall, thirdBall };
            var tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            foreach (Frame x in balls)
            {
                x.GestureRecognizers.Add(tap);
            }
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = sender as Frame;
            if (frame == firstBall || frame == secondBall || frame == thirdBall) {
                if (firstBall.Opacity != 0) { ShowSnowman(); hideShowButton.Text = "Спрятать"; }
                else { HideSnowman(); hideShowButton.Text = "Показать"; }
            }
        }

        private void HideSnowman() // исчезновение снеговика
        {
            firstBall.Opacity = 0;
            secondBall.Opacity = 0;
            thirdBall.Opacity = 0;
        }

        private void ShowSnowman() // появление снеговика
        {
            firstBall.Opacity = 100;
            secondBall.Opacity = 100;
            thirdBall.Opacity = 100;
        }

        private Color GetRandomColor() // получение случайного света
        {
            Random random = new Random();
            return Color.FromRgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }

        private Color GetColorFromSliders()
        {
            return Color.FromRgb(rSlider.Value, gSlider.Value, bSlider.Value);
        }

        private void rndClrButton_Clicked(object sender, EventArgs e)
        {
            foreach(Frame x in balls)
            {
                x.BackgroundColor = GetRandomColor();
            }
        }

        private void allPaintBtn_Clicked(object sender, EventArgs e)
        {
            foreach (Frame x in balls)
            {
                x.BackgroundColor = GetColorFromSliders();
            }
        }
    }
}