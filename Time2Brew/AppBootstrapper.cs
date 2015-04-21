using System;
using ReactiveUI;
using ReactiveUI.XamForms;
using Xamarin.Forms;
using Splat;
using Akavache;

namespace Time2Brew.Core
{
	public class AppBootstrapper : ReactiveObject, IScreen
	{
		// The Router holds the ViewModels for the back stack. Because it's
		// in this object, it will be serialized automatically.
		public RoutingState Router { get; protected set; }

		public AppBootstrapper ()
		{
			Router = new RoutingState ();

			Locator.CurrentMutable.RegisterConstant (this, typeof(IScreen));

			Locator.CurrentMutable.Register (() => new BoilAndHopStatsView (), typeof(IViewFor<BoilAndHopStatsViewModel>));
			Locator.CurrentMutable.Register (() => new BoilTimerView (), typeof(IViewFor<BoilTimerViewModel>));
			Locator.CurrentMutable.Register (() => new GeneralBrewStatsView (), typeof(IViewFor<GeneralBrewStatsViewModel>));
			Locator.CurrentMutable.Register (() => new MainPageView (), typeof(IViewFor<MainPageViewModel>));
			Locator.CurrentMutable.Register (() => new MashStatsView (), typeof(IViewFor<MashStatsViewModel>));
			Locator.CurrentMutable.Register (() => new MashTimerView (), typeof(IViewFor<MashTimerViewModel>));
			Locator.CurrentMutable.Register (() => new WaterProjectionsView (), typeof(IViewFor<WaterProjectionsViewModel>));
			Locator.CurrentMutable.Register (() => new UserPreferencesPage (), typeof(IViewFor<UserPreferencesPageViewModel>));
			Locator.CurrentMutable.Register (() => new BoolToTemperatureConverter (), typeof(IBindingTypeConverter));

			BlobCache.ApplicationName = "Time2Brew";
			BlobCache.EnsureInitialized ();

			Router.Navigate.Execute (new MainPageViewModel (this, new UserSettings ()));
		}

		public Page CreateMainPage ()
		{
			return new RoutedViewHost ();
		}
	}
}

