using System;
using ReactiveUI;
using System.Runtime.Serialization;
using Splat;

namespace Time2Brew.Core
{
	[DataContract]
	public class MashTimerViewModel : ReactiveObject, IRoutableViewModel
	{
		public MashTimerViewModel () : this (null)
		{
		}

		public MashTimerViewModel (IScreen hostScreen)
		{
			HostScreen = hostScreen ?? Locator.Current.GetService<IScreen> ();
		}

		[IgnoreDataMember]
		public string UrlPathSegment {
			get {
				return "Mash Timer";
			}
		}

		[IgnoreDataMember]
		public IScreen HostScreen { get; protected set; }
	}
}

