using System;
using Android.App;
using Android.Util;
using Android.Content;
using Android.OS;

namespace AndroidServiceDemo
{
	public interface IGetTimestamp
	{
		string GetFormattedTimestamp();
	}
	
}
