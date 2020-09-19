using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LumememmAppLaus
{
    public partial class MainPage
    {
        private Frame[] balls;
        public readonly int[] Colors = new int[3];
        public MainPage()
        {
            InitializeComponent();
            balls = new[] { FirstBall, SecondBall, ThirdBall };
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
            if (frame == FirstBall || frame == SecondBall || frame == ThirdBall)
            {
                if (frame != null) frame.BackgroundColor = GetColorFromSliders();
            }
        }

        private void HideSnowman() // исчезновение снеговика
        {
            FirstBall.Opacity = 0;
            SecondBall.Opacity = 0;
            ThirdBall.Opacity = 0;
        }

        private void ShowSnowman() // появление снеговика
        {
            FirstBall.Opacity = 100;
            SecondBall.Opacity = 100;
            ThirdBall.Opacity = 100;
        }

        private Color GetRandomColor() // получение случайного света
        {
            Random random = new Random();
            Colors[0] = random.Next(0, 256);
            Colors[1] = random.Next(0, 256);
            Colors[2] = random.Next(0, 256);
            return Color.FromRgb(Colors[0], Colors[1], Colors[2]);
        }

        private Color GetColorFromSliders()
        {
            return Color.FromRgb(Colors[0], Colors[1], Colors[2]);
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
                + Colors[0].ToString() + " G: " + Colors[1].ToString() + " B: " + Colors[2].ToString() + "?",
                "Да", "Нет");
            if (answer)
            {
                foreach (Frame x in balls)
                {
                    x.BackgroundColor = GetColorFromSliders();
                }
                DependencyService.Get<IMessage>().ShortAlert("Снеговик перекрашен.");
            }
        }

        private void ChangeColorsValues()
        {
            RText.Text = $"R: {Colors[0]}";
            RSlider.Value = Colors[0];
            GText.Text = $"G: {Colors[1]}";
            GSlider.Value = Colors[1];
            BText.Text = $"B: {Colors[2]}";
            BSlider.Value = Colors[2];
        }

        private void rSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue > 0)
            {
                Colors[0] = Convert.ToInt32(e.NewValue);
            }
            ChangeColorsValues();
        }

        private void gSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue > 0)
            {
                Colors[1] = Convert.ToInt32(e.NewValue);
            }
            ChangeColorsValues();
        }

        private void bSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue > 0)
            {
                Colors[2] = Convert.ToInt32(e.NewValue);
            }
            ChangeColorsValues();
        }

        private void hideShowButton_Clicked(object sender, EventArgs e)
        {
            if (FirstBall.Opacity != 0) { HideSnowman(); HideShowButton.Text = "Показать"; }
            else { ShowSnowman(); HideShowButton.Text = "Спрятать"; }
        }

        private async void meltSnowman_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IMessage>().ShortSnackbar("Упс, снеговик растоплен.");
            await Task.Run(() => {
                    for (int i = 0; i < 129; i++)
                    {
                        LayoutBackground.BackgroundColor = Color.FromRgb(255, 128+i, i * 2);
                        Thread.Sleep(10);
                    }
                HideSnowman();
                Thread.Sleep(1000);
                LayoutBackground.BackgroundColor = Color.Orange;
                ShowSnowman();
            });
        }
    }
}