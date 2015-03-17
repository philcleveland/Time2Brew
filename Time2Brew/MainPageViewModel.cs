using System;
using ReactiveUI;
using Splat;

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
		}

		public IScreen HostScreen {
			get;
			protected set;
		}

	}
}

