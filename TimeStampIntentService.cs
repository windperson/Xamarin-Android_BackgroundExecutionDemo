using Android.App;
using Android.Content;
using Android.Util;

namespace AndroidServiceDemo
{
    [Service]
    public class TimeStampIntentService : IntentService
    {
        private static readonly string TAG = typeof(TimeStampIntentService).FullName;

        public TimeStampIntentService() : base(nameof(TimeStampIntentService))
        {
        }

        protected override void OnHandleIntent(Intent intent)
        {
            Log.Debug(TAG, "Begin running of IntentService");

            var ret = GetTimeStamp();

            var resultIntent = new Intent(AndroidMessageTag.IntentServiceResult);
            resultIntent.PutExtra(AndroidMessageTag.ResultTimeStampKey, ret);

            Android.Support.V4.Content.LocalBroadcastManager.GetInstance(this).SendBroadcast(resultIntent);

            Log.Debug(TAG, "end of running IntentService");
        }

        private string GetTimeStamp()
        {
            var timestamper = new UtcTimestamper();
            return timestamper.GetFormattedTimestamp();
        }
    }
}