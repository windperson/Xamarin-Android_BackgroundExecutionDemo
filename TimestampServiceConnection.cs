using Android.Util;
using Android.OS;
using Android.Content;

namespace AndroidServiceDemo
{
	public class TimestampServiceConnection : Java.Lang.Object, IServiceConnection, IGetTimestamp
	{
		static readonly string TAG = typeof(TimestampServiceConnection).FullName;

	    readonly MainActivity _mainActivity;
		public TimestampServiceConnection(MainActivity activity)
		{
			IsConnected = false;
			Binder = null;
			_mainActivity = activity;
		}

		public bool IsConnected { get; private set; }
		public TimestampBinder Binder { get; private set; }

		public void OnServiceConnected(ComponentName name, IBinder service)
		{
			Binder = service as TimestampBinder;
			IsConnected = Binder != null;

            string message = "onServiceConnected - ";
			Log.Debug(TAG, $"OnServiceConnected {name.ClassName}");

			if (IsConnected)
			{
                message = message + " bound to service " + name.ClassName;
                _mainActivity.UpdateUiForBoundService();
			}
			else
			{
				message = message + " not bound to service " + name.ClassName;
                _mainActivity.UpdateUiForUnboundService();
			}

            Log.Info(TAG, message);
            _mainActivity.timestampMessageTextView.Text = message;

		}

		public void OnServiceDisconnected(ComponentName name)
		{
			Log.Debug(TAG, $"OnServiceDisconnected {name.ClassName}");
			IsConnected = false;
			Binder = null;
            _mainActivity.UpdateUiForUnboundService();
		}

		public string GetFormattedTimestamp()
		{
			if (!IsConnected)
			{
				return null;
			}

			return Binder?.GetFormattedTimestamp();
		}
	}

}
