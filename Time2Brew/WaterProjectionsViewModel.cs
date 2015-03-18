using System;
using System.Runtime.Serialization;
using ReactiveUI;
using Splat;

namespace Time2Brew.Core
{
	[DataContract]
	public class WaterProjectionsViewModel : ReactiveObject, IRoutableViewModel
	{
		public WaterProjectionsViewModel () : this (null)
		{
		}

		public WaterProjectionsViewModel (IScreen hostScreen)
		{
			HostScreen = hostScreen ?? Locator.Current.GetService<IScreen> ();

		}

		[IgnoreDataMember]
		public string UrlPathSegment {
			get {
				return "Water Projections";
			}
		}

		[IgnoreDataMember]
		public IScreen HostScreen { get; protected set; }
	}
}

