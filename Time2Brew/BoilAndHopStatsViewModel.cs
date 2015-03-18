using System;
using System.Runtime.Serialization;
using ReactiveUI;
using Splat;

namespace Time2Brew.Core
{
	[DataContract]
	public class BoilAndHopStatsViewModel : ReactiveObject, IRoutableViewModel
	{
		public BoilAndHopStatsViewModel () : this (null)
		{
		}

		public BoilAndHopStatsViewModel (IScreen hostScreen)
		{
			HostScreen = hostScreen ?? Locator.Current.GetService<IScreen> ();

		}

		[IgnoreDataMember]
		public string UrlPathSegment {
			get {
				return "Boil and Hop Stats";
			}
		}

		[IgnoreDataMember]
		public IScreen HostScreen { get; protected set; }
	}
}

