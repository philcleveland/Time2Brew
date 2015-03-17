using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using ReactiveUI;
using Xamarin.Forms.Platform.Android;
using Time2Brew.Core;

namespace Time2Brew.Droid
{
	[Activity (Label = "Time2Brew.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FormsApplicationActivity
	{
		public MainActivity ()
		{
			Console.WriteLine ("Start");
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			Forms.Init (this, bundle);

			var mainPage = RxApp.SuspensionHost.GetAppState<AppBootstrapper> ().CreateMainPage ();
//			var bs = new AppBootstrapper ();
//			var mainPage = bs.CreateMainPage ();
			this.SetPage (mainPage);

//			this.LoadApplication (new App ());

		}
	}
}

