using System;

using Xamarin.Forms;
using ReactiveUI;

namespace Time2Brew.Core
{
	public class App : Application
	{
		public App ()
		{
			var bootstrapper = RxApp.SuspensionHost.GetAppState<AppBootstrapper> ();
//
			var mainPage = bootstrapper.CreateMainPage ();
			MainPage = mainPage;
			// The root page of your application
//			MainPage = new ContentPage {
//				Content = new StackLayout {
//					VerticalOptions = LayoutOptions.Center,
//					Children = {
//						new Label {
//							XAlign = TextAlignment.Center,
//							Text = "Welcome to Xamarin Forms buddy!"
//						}
//					}
//				}
//			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

