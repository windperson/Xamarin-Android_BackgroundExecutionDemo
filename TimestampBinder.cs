using System;
using Android.App;
using Android.Util;
using Android.Content;
using Android.OS;

namespace AndroidServiceDemo
{
	public class TimestampBinder : Binder, IGetTimestamp
	{
	    private TimestampService _service;

	    public TimestampBinder(TimestampService service)
		{
			_service = service;
		}

		public string GetFormattedTimestamp()
		{
			return _service?.GetFormattedTimestamp();
		}
	}	
}
