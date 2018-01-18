using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace AndroidServiceDemo
{
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		Button timestampButton;
		TextView timestampMessageTextView;

	    private TimestampIntentServiceBroadCastReceiver _receiver;


		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);

			timestampButton = FindViewById<Button>(Resource.Id.get_timestamp_button);

		    timestampMessageTextView = FindViewById<TextView>(Resource.Id.message_textview);

            _receiver = new TimestampIntentServiceBroadCastReceiver
            {
                ReceiveHandler = result =>
                {
                    if (timestampMessageTextView != null)
                    {
                        timestampMessageTextView.Text = result;
                    }
                }
            };

		}

        protected override void OnResume()
        {
            base.OnResume();
            timestampButton.Click += GetTimestampButton_Click;

            Android.Support.V4.Content.LocalBroadcastManager.GetInstance(this).RegisterReceiver(_receiver, new IntentFilter(AndroidMessageTag.IntentServiceResult));
        }

        protected override void OnPause()
		{
			timestampButton.Click -= GetTimestampButton_Click;

		    Android.Support.V4.Content.LocalBroadcastManager.GetInstance(this).UnregisterReceiver(_receiver);

			base.OnPause();
		}

		void GetTimestampButton_Click(object sender, System.EventArgs e)
		{
            var intent = new Intent(this, typeof(TimeStampIntentService));
		    StartService(intent);
		}

	    public void UpdateTimeStampTExtView(string text)
	    {
	        timestampMessageTextView.Text = text;
	    }
	}
}

