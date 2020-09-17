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
        public int[] colors = new int[3];
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
            GetRandomColor();
            ChangeColorsValues();
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = sender as Frame;
            if (frame == firstBall || frame == secondBall || frame == thirdBall) {
                frame.BackgroundColor = GetColorFromSliders();
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
            colors[0] = random.Next(0, 256);
            colors[1] = random.Next(0, 256);
            colors[2] = random.Next(0, 256);
            return Color.FromRgb(colors[0], colors[1], colors[2]);
        }

        private Color GetColorFromSliders()
        {
            return Color.FromRgb(colors[0], colors[1], colors[2]);
        }

        private void rndClrButton_Clicked(object sender, EventArgs e)
        {
            foreach(Frame x in balls)
            {
                x.BackgroundColor = GetRandomColor();
            }
            ChangeColorsValues();
        }

        private async void allPaintBtn_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Перекрасить",
                "Изменить цвета снеговика в\nR: "
                + colors[0].ToString() + " G: " + colors[1].ToString() + " B: " + colors[2].ToString() + "?",
                "Да", "Нет");
            if (answer)
            {
                foreach (Frame x in balls)
                {
                    x.BackgroundColor = GetColorFromSliders();
                }
            }
        }

        private void ChangeColorsValues()
        {
            rText.Text = $"R: {colors[0]}";
            rSlider.Value = colors[0];
            gText.Text = $"G: {colors[1]}";
            gSlider.Value = colors[1];
            bText.Text = $"B: {colors[2]}";
            bSlider.Value = colors[2];
        }

        private void rSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue > 0)
            {
                colors[0] = Convert.ToInt32(e.NewValue);
            }
            ChangeColorsValues();
        }

        private void gSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue > 0)
            {
                colors[1] = Convert.ToInt32(e.NewValue);
            }
            ChangeColorsValues();
        }

        private void bSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue > 0)
            {
                colors[2] = Convert.ToInt32(e.NewValue);
            }
            ChangeColorsValues();
        }

        private void hideShowButton_Clicked(object sender, EventArgs e)
        {
            if (firstBall.Opacity != 0) { HideSnowman(); hideShowButton.Text = "Показать"; }
            else { ShowSnowman(); hideShowButton.Text = "Спрятать"; }
        }

        private async void meltSnowman_Clicked(object sender, EventArgs e)
        {
            await Task.Run(() => {
                    for (int i = 0; i < 129; i++)
                    {
                        layoutBackground.BackgroundColor = Color.FromRgb(255, 128+i, i * 2);
                        Thread.Sleep(10);
                    }
                HideSnowman();
                Thread.Sleep(1000);
                layoutBackground.BackgroundColor = Color.Orange;
                ShowSnowman();
            });
        }
    }
}