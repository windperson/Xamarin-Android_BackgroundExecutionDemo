using System;
using Android.App;
using Android.Content;

namespace AndroidServiceDemo
{
    [BroadcastReceiver(Enabled = true, Exported = false)]
    public class TimestampIntentServiceBroadCastReceiver : BroadcastReceiver
    {
        public Action<string> ReceiveHandler { get; set; }

        public override void OnReceive(Context context, Intent intent)
        {
            var timeStamp = intent.GetStringExtra(AndroidMessageTag.ResultTimeStampKey);

            ReceiveHandler?.Invoke(timeStamp);
        }
    }
}