using System;
using ReactiveUI;
using Splat;
using System.Reactive.Linq;

namespace Time2Brew.Core
{
	public class MainPageViewModel : ReactiveObject, IRoutableViewModel
	{
		public string UrlPathSegment {
			get { return "Time 2 Brew"; }
		}

		public MainPageViewModel () : this (null)
		{
		}

		public MainPageViewModel (IScreen hostScreen)
		{
			HostScreen = hostScreen ?? Locator.Current.GetService<IScreen> ();

			NavigateStartBrewing = ReactiveCommand.Create ();
			NavigateStartBrewing
				.ObserveOn (RxApp.MainThreadScheduler)
				.Subscribe (_ => HostScreen.Router.Navigate.Execute (new GeneralBrewStatsViewModel (HostScreen)));
		}

		public IScreen HostScreen {
			get;
			protected set;
		}

		public ReactiveCommand<object> NavigateStartBrewing { get; private set; }
	}
}

