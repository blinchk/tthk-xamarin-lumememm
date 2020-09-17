using Android.App;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(LumememmAppLaus.Droid.MessagesAndroid))]
namespace LumememmAppLaus.Droid
{
    public class MessagesAndroid : IMessage
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}