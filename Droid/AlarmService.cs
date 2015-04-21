using System;
using Android.App;

namespace Time2Brew.Droid
{
	[Service]
	public class AlarmService : Service
	{
		public AlarmService ()
		{
		}

		#region implemented abstract members of Service

		public override Android.OS.IBinder OnBind (Android.Content.Intent intent)
		{
			
			return null;
		}

		#endregion

		public override StartCommandResult OnStartCommand (Android.Content.Intent intent, StartCommandFlags flags, int startId)
		{
			return StartCommandResult.Sticky;
		}
	}
}

