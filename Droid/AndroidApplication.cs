using System;
using Android.App;
using ReactiveUI;
using Android.Runtime;
using Time2Brew.Core;

namespace Time2Brew.Droid
{
	[Application (Label = "Time2Brew")]
	public class AndroidApplication : Application
	{
		AutoSuspendHelper _autoSuspendHelper;

		public AndroidApplication (IntPtr handle, JniHandleOwnership transfer) : base (handle, transfer)
		{
		}

		public override void OnCreate ()
		{
			base.OnCreate ();

			_autoSuspendHelper = new AutoSuspendHelper (this);

			// CoolStuff: The job of AutoSuspendHelper is, that it will 
			// automatically save and reload exactly *one* object of your 
			// choice when the app is suspended. If the object can't be
			// reloaded (i.e. if the app is starting for the first time),
			// we're telling ReactiveUI here how to create a new one from
			// scratch.
			RxApp.SuspensionHost.CreateNewAppState = () => new AppBootstrapper ();

			RxApp.SuspensionHost.SetupDefaultSuspendResume ();
		}
	}
}

