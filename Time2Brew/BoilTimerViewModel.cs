using System;
using System.Runtime.Serialization;
using ReactiveUI;

namespace Time2Brew.Core
{
	[DataContract]
	public class BoilTimerViewModel : ReactiveObject, IRoutableViewModel
	{
		public BoilTimerViewModel ()
		{
		}

		public BoilTimerViewModel (IScreen hostScreen)
		{
			
		}

		[IgnoreDataMember]
		public string UrlPathSegment {
			get {
				return "Boil Timer";
			}
		}

		[IgnoreDataMember]
		public IScreen HostScreen { get; protected set; }
	}
}

