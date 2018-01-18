using System;
using Android.App;
using Android.Util;
using Android.Content;
using Android.OS;

namespace AndroidServiceDemo
{

	public class UtcTimestamper : IGetTimestamp
	{
		public string GetFormattedTimestamp()
		{
		    var now = DateTime.Now;
			return $"Service invoked at {now} .";
		}

	}
	
}
